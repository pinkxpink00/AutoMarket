using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    public class CarController : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            return View(response);
        }
    }
}
