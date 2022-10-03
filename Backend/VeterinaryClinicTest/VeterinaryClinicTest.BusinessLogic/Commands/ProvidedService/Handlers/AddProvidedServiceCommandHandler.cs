using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Handlers
{
    public class AddProvidedServiceCommandHandler : IRequestHandler<AddProvidedServiceCommandModel,int>
    {
        private readonly IProvidedServicesCommandsService _providedServiceCommandService;
        public AddProvidedServiceCommandHandler(IProvidedServicesCommandsService providedServicesCommandService)
        {
            _providedServiceCommandService = providedServicesCommandService;
        }

        public async Task<int> Handle(AddProvidedServiceCommandModel request, CancellationToken cancellationToken)
        {
            var serviceId = await _providedServiceCommandService.AddAsync(request,cancellationToken);
            return serviceId;
        }
    }
}

