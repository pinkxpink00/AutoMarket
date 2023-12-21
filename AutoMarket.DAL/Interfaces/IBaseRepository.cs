using AutoMarket.Domain.Models;

namespace AutoMarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task <T> GetAsync(int id);

        Task<List<T>> Select();

        Task<bool> Delete(T entity);
    }
}
