using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using Fitness.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DietsCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DietsCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<DietsCategory> objDietList = _unitOfWork.DietsCategory.GetAll().ToList();
            return View(objDietList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DietsCategory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DietsCategory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kategoria diety utworzona pomyślnie.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DietsCategory? dietCategoryFromDb = _unitOfWork.DietsCategory.Get(u => u.Id == id);
            if (dietCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(dietCategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(DietsCategory obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DietsCategory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kategoria diety zostałą pomyślnie zedytowana.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DietsCategory? dietCategoryFromDb = _unitOfWork.DietsCategory.Get(u => u.Id == id);
            if (dietCategoryFromDb == null)
            {
                return NotFound();
            }
            return View(dietCategoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            DietsCategory? obj = _unitOfWork.DietsCategory.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.DietsCategory.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kategoria diety została usunięta.";
            return RedirectToAction("Index");
        }
    }
}
