using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Enum;
using Automarket.Domain.Extensions;
using AutoMarket.Domain.Models;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;

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
    }
}
