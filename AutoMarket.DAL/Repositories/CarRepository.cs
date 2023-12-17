using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            db = _db;
        }

        public bool Create(Car entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public Car GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> Select()
        {
            return _db.Car.ToListAsync();
        }
    }
}
