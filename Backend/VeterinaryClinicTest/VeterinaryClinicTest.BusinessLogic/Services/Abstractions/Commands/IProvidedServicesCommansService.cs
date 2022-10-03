using System;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands
{
    public interface IProvidedServicesCommandsService
    {
        Task<int> AddAsync(AddProvidedServiceCommandModel providedServiceAdd, CancellationToken token);
    }
}

