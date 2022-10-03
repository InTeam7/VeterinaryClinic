using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Handlers
{
    public class AddClinicServiceCommandHandler : IRequestHandler<AddClinicServiceCommandModel,int>
    {
        private readonly IClinicServiceCommandsService _clinicServiceCommandService;
        public AddClinicServiceCommandHandler(IClinicServiceCommandsService clinicServiceCommandService)
        {
            _clinicServiceCommandService = clinicServiceCommandService;
        }

        public async Task<int> Handle(AddClinicServiceCommandModel request, CancellationToken cancellationToken)
        {
            var serviceId = await _clinicServiceCommandService.AddAsync(request, cancellationToken);
            return serviceId;
        }
    }
}

