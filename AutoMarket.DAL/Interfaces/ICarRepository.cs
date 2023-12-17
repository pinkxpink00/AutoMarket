using AutoMarket.Domain.Models;

namespace AutoMarket.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Car GetByName (string name);
    }
}
