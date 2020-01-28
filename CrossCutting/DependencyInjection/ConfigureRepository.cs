using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));
            /*serviceCollection.AddDbContext<MyContext>(
               options => options.UseMySql("Server=127.0.0.1;Port=3306;Database=apidb;Uid=root;Password=root1234567"));*/

            serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer("Server =.\\SQLEXPRESS;Database=apidb;Uid=sa;Password=root123"));
        }
    }
}
