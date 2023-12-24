using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Enum;
using AutoMarket.Domain.Models;
using AutoMarket.Domain.Response;
using AutoMarket.Service.Interfaces;

namespace AutoMarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;

                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }

            return baseResponse;
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();

            try
            {
                var cars = await _carRepository.Select();
                if (cars.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK;
                
                

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }
        }
    }
}
