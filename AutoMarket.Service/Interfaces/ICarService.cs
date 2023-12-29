using AutoMarket.Domain.Models;
using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.Car;

namespace AutoMarket.Service.Interfaces
{
    public interface ICarService
    {
        Task <IBaseResponse<IEnumerable<Car>>> GetCars();

        Task<IBaseResponse<Car>> GetCar(long id);

        Task<IBaseResponse<bool>> DeleteCar(long id);

        Task<IBaseResponse<Car>> Edit(long id, CarViewModel model);
    }
}
