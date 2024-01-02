using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Enum;
using Automarket.Domain.Extensions;
using AutoMarket.Domain.Models;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using AutoMarket.DAL.Repositories;

namespace AutoMarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<Car> _carRepository;

        public CarService(IBaseRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeCar[])Enum.GetValues(typeof(TypeCar)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
                var cars = _carResponse.GetAll().ToList();

            }
            catch (Exception ex)
            {
              
            }
        }

        public Task<IBaseResponse<CarViewModel>> GetCar(long id)
        {
            try
            {
                var car = await _carResponse.GetAll();
            }
            catch (Exception ex)
            {

            }
        }

        public Task<BaseResponse<Dictionary<long, string>>> GetCar(string term)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Car>> Create(CarViewModel car, byte[] imageData)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> DeleteCar(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<Car>> Edit(long id, CarViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
