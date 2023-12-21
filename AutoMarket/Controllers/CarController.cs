using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carRepository.Select();
            var secondResponse = await _carRepository.GetByName("CarName1");
            var thirtyResponse = await _carRepository.GetAsync(3);

            var newCar = new Car
            {
                Name = "BMW",
                Model = "320",
                Description = "Gasoline Auto",
                Speed = 320,
                Price = 1,
                DateCreate = DateTime.UtcNow
            };
            
            await _carRepository.Create(newCar);
            await _carRepository.Delete(newCar);
            return View(response);
        }
    }
}
