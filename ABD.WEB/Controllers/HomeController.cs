using ABD.BusinessService.Services.Abstract;
using ABD.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ABD.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _ICustomerService;
        public HomeController(ICustomerService ICustomerService)
        {
            this._ICustomerService = ICustomerService;
        }
        public IActionResult Index()
        {
            var data=_ICustomerService.getCustomers();
            return View();
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
