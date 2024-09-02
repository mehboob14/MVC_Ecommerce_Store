using Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.dataAccess.Repositry;
using Web.dataAccess.Repositry.IRepositry;


namespace day_01.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unit)
        {
            _logger = logger;
           _unitOfWork = unit;
        }

        public IActionResult Index()
            
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"category");
            return View(productList);
        }
        public IActionResult Details(int id)

        {
            Product product = _unitOfWork.Product.Get(u=>u.Id==id,includeProperties: "category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
