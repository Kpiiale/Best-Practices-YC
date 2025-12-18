using Best_Practices.Controllers;
using Best_Practices.Infrastructure.Factories;
using Best_Practices.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infrastructure.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddProjectDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
            services.AddTransient<IVehicleFactory, FordEscapeCreator>();
        }
    }
}
