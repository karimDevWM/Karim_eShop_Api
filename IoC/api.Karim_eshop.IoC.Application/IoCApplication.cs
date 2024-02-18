//using api.Karim_eshop.Business.Service;
//using api.Karim_eshop.Business.Service.Contract;
using api.Karim_eshop.Data.Context.Contract;
using api.Karim_eshop.Data.Entity;
//using api.Karim_eshop.Data.Repository;
//using api.Karim_eshop.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Karim_eshop.IoC.Application
{
    public static class IoCApplication
    {
        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Repositories

            //services.AddScoped<IProduitRepository, ProduitRepository>();

            return services;
        }

        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Services

            //services.AddScoped<IProduitService, ProduitService>();

            return services;
        }

        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BddConnection");

            services.AddDbContext<KarimeshopDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            return services;
        }
    }
}
