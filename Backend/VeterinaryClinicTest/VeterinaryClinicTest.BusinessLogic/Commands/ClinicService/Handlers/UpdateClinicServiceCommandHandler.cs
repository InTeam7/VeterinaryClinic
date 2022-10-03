using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Handlers
{
    public class UpdateClinicServiceCommandHandler : IRequestHandler<UpdateClinicServiceCommandModel,Unit>
    {
        private readonly IClinicServiceCommandsService _clinicServiceCommandService;
        public UpdateClinicServiceCommandHandler(IClinicServiceCommandsService clinicServiceCommandService)
        {
            _clinicServiceCommandService = clinicServiceCommandService;
        }

        public async Task<Unit> Handle(UpdateClinicServiceCommandModel request, CancellationToken cancellationToken)
        {
            await _clinicServiceCommandService.UpdateAsync(request, cancellationToken);
            return Unit.Value;
        }
    }
}

