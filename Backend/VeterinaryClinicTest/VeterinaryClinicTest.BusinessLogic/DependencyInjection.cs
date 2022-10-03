using System;
using MediatR;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VeterinaryClinicTest.BusinessLogic.Mappers;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Common;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Helpers;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Helpers;

namespace VeterinaryClinicTest.BusinessLogic
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddBusinessLogic(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AnimalProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<ClinicServiceProfile>();
                cfg.AddProfile<DoctorProfile>();
                cfg.AddProfile<ProvidedServiceProfile>();
                cfg.AddProfile<VaccineProfile>();

            });

            services.AddMemoryCache();
            services.AddScoped<IAnimalCommandsService, AnimalCommandService>();
            services.AddScoped<IClientCommandsService, ClientCommandService>();
            services.AddScoped<IClinicServiceCommandsService, ClinicServiceCommandsService>();
            services.AddScoped<IDoctorCommandsService, DoctorCommandsService>();
            services.AddScoped<IProvidedServicesCommandsService, ProvidedServicesCommandsService>();
            services.AddScoped<IVaccineCommandsService, VaccineCommandsService>();

            services.AddScoped<IAnimalQueryService, AnimalQueryService>();
            services.AddScoped<IClientQueryService, ClientQueryService>();
            services.AddScoped<IClinicServiceQueryService, ClinicServiceQueryService>();
            services.AddScoped<IDoctorQueryService, DoctorQueryService>();
            services.AddScoped<IProvidedServicesQueryService, ProvidedServicesQueryService>();
            services.AddScoped<IVaccineQueryService, VaccineQueryService>();

            services.AddScoped<ISearchClientService, ClientSearch>();

            return services;
        }
    }
}

