using AutoMarket.DAL.Interfaces;
using AutoMarket.DAL.Repositories;
using AutoMarket.Domain.Models;
using AutoMarket.Service.Implementations;
using AutoMarket.Service.Interfaces;

namespace AutoMarket
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Car>, CarRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
        }
    }
}
