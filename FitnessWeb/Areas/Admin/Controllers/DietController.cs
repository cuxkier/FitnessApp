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
    public class DietController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DietController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            List<Diet> objDietList = _unitOfWork.Diet.GetAll(includeProperties: "DietsCategory").ToList();

            return View(objDietList);
        }

        public IActionResult Upsert(int? id)
        {
            DietVM dietVM = new()
            {
                DietsCategoryList = _unitOfWork.DietsCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString(),
                }),
                Diet = new Diet()
            };

            if (id == null || id == 0)
            {
                //create
                return View(dietVM);
            }
            else
            {
                //update
                dietVM.Diet = _unitOfWork.Diet.Get(u => u.Id == id);
                return View(dietVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(DietVM dietVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string dietPath = Path.Combine(wwwRootPath, @"images\diet");

                    if (!string.IsNullOrEmpty(dietVM.Diet.ImageUrl))
                    {
                        //delete old img
                        var oldImagePath = Path.Combine(wwwRootPath, dietVM.Diet.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(dietPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    dietVM.Diet.ImageUrl = @"\images\diet\" + fileName;
                }
                if (dietVM.Diet.Id == 0)
                {
                    _unitOfWork.Diet.Add(dietVM.Diet);
                    TempData["success"] = "Dieta utworzona pomyślnie.";
                }
                else
                {
                    _unitOfWork.Diet.Update(dietVM.Diet);
                    TempData["success"] = "Dieta edytowana pomyślnie.";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                dietVM.DietsCategoryList = _unitOfWork.DietsCategory.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString(),
                });
                return View(dietVM);
            }
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Diet> objDietList = _unitOfWork.Diet.GetAll(includeProperties: "DietsCategory").ToList();
            return Json(new { data = objDietList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var dietToBeDeleted = _unitOfWork.Diet.Get(u => u.Id == id);
            if (dietToBeDeleted == null)
            {
                return Json(new { success = false, message = "Błąd podczas usuwania diety" });
            }

            if (!string.IsNullOrEmpty(dietToBeDeleted.ImageUrl))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, dietToBeDeleted.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.Diet.Remove(dietToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Dieta została usunięta" });
        }


        #endregion
    }
}
