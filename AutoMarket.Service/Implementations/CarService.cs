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
        private readonly IBaseResponse<Car> _carResponse;

        public CarService(IBaseResponse<Car> carResponse)
        {
            _carResponse = carResponse;
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
                if (!cars.Any())
                {
                    return new BaseResponse<List<Car>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<CarViewModel>> GetCar(long id)
        {
            throw new NotImplementedException();
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
