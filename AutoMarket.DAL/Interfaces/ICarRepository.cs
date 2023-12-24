using AutoMarket.Domain.Models;

namespace AutoMarket.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetCarByName(string name);
    }
}
