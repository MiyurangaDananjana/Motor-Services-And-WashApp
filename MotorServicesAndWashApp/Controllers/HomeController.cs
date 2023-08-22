using Microsoft.AspNetCore.Mvc;
using MotorServicesAndWashApp.Data;
using MotorServicesAndWashApp.Models;
using System.Diagnostics;

namespace MotorServicesAndWashApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MotorServiceDbContext _DbContext;
        
        public HomeController(ILogger<HomeController> logger, MotorServiceDbContext motorServiceDbContext)
        {
            _logger = logger;
            this._DbContext = motorServiceDbContext;
        }

        public IActionResult Index()
        {
            string Key = "MotorService";
            var Cookie = Request.Cookies[Key];
            var isCheckCookie = _DbContext.UserSesstions.FirstOrDefault(x => x.Sesston == Cookie);
            if(isCheckCookie != null)
            {
                  return RedirectToAction("Main", "Components");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
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