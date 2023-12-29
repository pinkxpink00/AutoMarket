using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Enum;
using AutoMarket.Domain.Models;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;
using AutoMarket.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<CarViewModel>> GetCar(long id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<CarViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var data = new CarViewModel()
                {
                    DateCreate = Convert.ToDateTime(car.DateCreate.ToLongDateString()),
                    Description = car.Description,
                    Name = car.Name,
                    Price = car.Price,
                    TypeCar = car.TypeCar.GetDisplayName(),
                    Speed = car.Speed,
                    Model = car.Model,
                    Image = car.Avatar,
                };

                return new BaseResponse<CarViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> CreateCar(CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var car = new Car()
                {
                    Description = carViewModel.Description,
                    DateCreate = DateTime.Now,
                    Speed = carViewModel.Speed,
                    Model = carViewModel.Model,
                    Price = carViewModel.Price,
                    Name = carViewModel.Name,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
                };

                await _carRepository.Create(car);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateCar] : {ex.Message}"
                };
            }

            return baseResponse;
        }


        public async Task<IBaseResponse<bool>> DeleteCar(long id)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "User not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }

                await _carRepository.Delete(car);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.GetCarByName(name);
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
                    Description = $"[GetCarByName] : {ex.Message}"
                };
            }

            return baseResponse;
        }

        public async Task<IBaseResponse<Car>> Edit(long id, CarViewModel model)
        {
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.CarNotFound
                    };
                }

                car.Description = model.Description;
                car.Model = model.Model;
                car.Price = model.Price;
                car.Speed = model.Speed;
                car.DateCreate = Convert.ToDateTime(model.DateCreate);
                car.Name = model.Name;

                await _carRepository.Update(car);


                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.OK,
                };
                // TypeCar
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
                var cars = _carRepository.GetAll().ToList();
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

    }
}
