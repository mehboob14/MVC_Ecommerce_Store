
using Web.Models;
using Microsoft.AspNetCore.Mvc;
using Web.dataAccess.Data;
using Web.dataAccess.Repositry.IRepositry;
using Web.dataAccess.Repositry;

namespace day_01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();

            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrders.ToString())
            {
                ModelState.AddModelError("name", "The Display order can't eactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index"); // RedirectToAction("Index","Controller Name"); optoinnal
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == 0)
            {
                return NotFound();
            }
            Category categoryObj = _unitOfWork.Category.Get(u => u.Id == id); // it only works on primary key
                                                                              // Category? categoryObj2 = _db.Categories.FirstOrDefault(u => u.Name== "Name");//u.Name.contains()also works
            if (categoryObj == null)
            {
                return NotFound();
            }
            return View(categoryObj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == 0)
            {
                return NotFound();
            }
            Category categoryObj = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryObj == null)
            {
                return NotFound();
            }
            return View(categoryObj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category categoryObj = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryObj != null)
            {
                _unitOfWork.Category.Remove(categoryObj);
                _unitOfWork.Save();
            }

            return RedirectToAction("Index");

        }

    }
}
