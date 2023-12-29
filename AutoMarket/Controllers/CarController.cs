using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCars();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data); 
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var response = await _carService.DeleteCar(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(GetCars()); 
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel viewModel)
        {
            ModelState.Remove("Id");
            ModelState.Remove("DateCreate");
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(viewModel.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)viewModel.Avatar.Length);
                    }
                    await _carService.Create(viewModel, imageData);
                }
                else
                {
                    await _carService.Edit(viewModel.Id, viewModel);
                }
            }
            return RedirectToAction("GetCars");
        }

    }
}
