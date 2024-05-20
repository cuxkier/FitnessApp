using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using Fitness.Models.ViewModels;
using Fitness.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Fitness.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = SD.Role_Admin)]
    public class DietsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DietsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            List<Diet> objDietList = _unitOfWork.Diets.GetAll(includeProperties:"DietsCategory").ToList();
            
            return View(objDietList);
        }

        public IActionResult Upsert(int? id)
        {
            DietsVM dietsVM = new()
            {
                DietsCategoryList = _unitOfWork.DietsCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString(),
                }),
            Diets = new Diet()
            };
            if(id == null || id == 0)
            {
                //create
                return View(dietsVM);
            }
            else
            {
                //update
                dietsVM.Diets = _unitOfWork.Diets.Get(u => u.Id == id);
                return View(dietsVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(DietsVM dietsVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file!=null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string dietsPath = Path.Combine(wwwRootPath, @"images/diets");

                    if(!string.IsNullOrEmpty(dietsVM.Diets.ImageUrl))
                    {
                        //delete old img
                        var oldImagePath = Path.Combine(wwwRootPath, dietsVM.Diets.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(dietsPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    dietsVM.Diets.ImageUrl = @"\images\diets\" + fileName;
                }
                if(dietsVM.Diets.Id == 0)
                {
                    _unitOfWork.Diets.Add(dietsVM.Diets);
                }
                else
                {
                    _unitOfWork.Diets.Update(dietsVM.Diets);
                }
                _unitOfWork.Save();
                TempData["success"] = "Kategoria diety utworzona pomyślnie.";
                return RedirectToAction("Index");
            }
            else
            {
                dietsVM.DietsCategoryList = _unitOfWork.DietsCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString(),
                });
                return View(dietsVM);
            }
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Diet> objDietList = _unitOfWork.Diets.GetAll(includeProperties: "DietsCategory").ToList();
            return Json(new {data = objDietList});
        }    
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var dietToBeDeleted = _unitOfWork.Diets.Get(u => u.Id == id);
            if (dietToBeDeleted == null)
            {
                return Json(new { success = false, messege = "Błąd podczas usuwania diety" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, 
                dietToBeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Diets.Remove(dietToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, messege = "Dieta została usunięta" });
        }

        #endregion
    }
}
