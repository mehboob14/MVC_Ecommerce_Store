using Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.dataAccess.Repositry;


namespace day_01.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, UnitOfWork unit)
        {
            _logger = logger;
            _unitOfWork = unit;
        }

        public IActionResult Index()
            
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "category");
            return View(productList);
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
