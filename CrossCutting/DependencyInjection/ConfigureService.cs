using Domain.Interfaces.Services.Administrators;
using Domain.Interfaces.Services.Bookings;
using Domain.Interfaces.Services.VIsitors;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IVisitorService, VisitorService>();
            serviceCollection.AddTransient<IAdministratorService, AdministratorService>();
            serviceCollection.AddTransient<IBookingService, BookingService>();
        }
    }
}
