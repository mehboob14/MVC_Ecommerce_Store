using day_01.Data;
using day_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace day_01.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbConteXt _db;
        public CategoryController(ApplicationDbConteXt db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        public string stringView(string id)
        {
            string result = $"this is simple string and id is : {id}";
            return result;
        }
       /* public IActionResult idView(int id)
        {
            return Content { new ContentResult =id.ToString() };
        }*/
    }
}
