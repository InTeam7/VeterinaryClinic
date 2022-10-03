using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Handlers
{
    public class DeleteClinicServiceCommandHandler:IRequestHandler<DeleteClinicServiceCommandModel,Unit>
    {
        private readonly IClinicServiceCommandsService _clinicServiceCommandService;
        public DeleteClinicServiceCommandHandler(IClinicServiceCommandsService clinicServiceCommandService)
        {
            _clinicServiceCommandService = clinicServiceCommandService;
        }

        public async Task<Unit> Handle(DeleteClinicServiceCommandModel request, CancellationToken cancellationToken)
        {
            await _clinicServiceCommandService.DeleteAsync(request, cancellationToken);
            return Unit.Value;
        }
    }
}

