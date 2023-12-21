using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Car entity)
        {
            await _db.Car.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
            _db.Car.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Car> GetAsync(int id)
        {
            return await _db.Car.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _db.Car.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<List<Car>> Select()
        {
            return _db.Car.ToListAsync();
        }
    }
}
