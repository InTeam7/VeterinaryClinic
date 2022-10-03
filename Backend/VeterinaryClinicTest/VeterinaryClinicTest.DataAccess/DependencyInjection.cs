using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeterinaryClinicTest.DataAccess.Abstractions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Implementation;
using VeterinaryClinicTest.DataAccess.Implementation.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ClinicDBContext>(options =>
            {
                options.UseLazyLoadingProxies(false);
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IDBContext>(provider =>
                provider.GetService<ClinicDBContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClinicServiceRepository, ClinicServiceRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IProvidedServiceRepository, ProvidedServiceRepository>();
            services.AddScoped<IVaccineRepository, VaccineRepository>();

            return services;
        }
    }
}

