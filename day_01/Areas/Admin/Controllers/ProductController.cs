using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.dataAccess.Repositry.IRepositry;
using Web.Models;
using Web.Models.ViewModels;

namespace day_01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvirnment;
       public ProductController(IUnitOfWork iunitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = iunitofwork;
            _webHostEnvirnment = webHostEnvironment;
        }

        public IActionResult Index()
        { 
        List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"category").ToList();
            //ViewBag
            return View(objProductList);
        }


        public IActionResult Upsert(int? id)
        {

            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,//projection
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if(id ==0 || id == null)
            {
                return View(productVM);
            }else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
           
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {

            string wwwroot = _webHostEnvirnment.WebRootPath;
            if(file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productpath = Path.Combine(wwwroot, @"Images/Product");


                if (!string.IsNullOrEmpty(obj.Product.ImageUrl)) 
                {
                    //delete old image
                    var oldImage = Path.Combine(wwwroot, obj.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }

                using(var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.Product.ImageUrl = @"/Images/Product/"+filename;
            }


            if(obj.Product.Id == 0)
            {
                _unitOfWork.Product.Add(obj.Product);
            }else
            {
                _unitOfWork.Product.Update(obj.Product);
            }  
                _unitOfWork.Save();
                return RedirectToAction("Index"); //RedirectToAction("Index","Controller Name"); optoinnal
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
            Product productObj = _unitOfWork.Product.Get(u => u.Id == id);
            if (productObj == null)
            {
                return NotFound();
            }
            return View(productObj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product productObj = _unitOfWork.Product.Get(u => u.Id == id);

            if (productObj != null)
            {
                _unitOfWork.Product.Remove(productObj);
                _unitOfWork.Save();
            }

            return RedirectToAction("Index");

        }
    }
}
