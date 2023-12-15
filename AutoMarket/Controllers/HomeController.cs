using AutoMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMarket.Domain.Models;

namespace AutoMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Car car = new Car()
            {
                Name = "BMW",
                Speed = 40000,
                Model = "320i",
                Id = 1,
            };
            return View(car);
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
