using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Handlers
{
    public class DeleteVaccineCommandHandler : IRequestHandler<DeleteVaccineCommandModel, Unit>
    {
        private readonly IVaccineCommandsService _vaccineCommandService;

        public DeleteVaccineCommandHandler(IVaccineCommandsService vaccineCommandsService)
        {
            _vaccineCommandService = vaccineCommandsService;
        }

        public async Task<Unit> Handle(DeleteVaccineCommandModel request, CancellationToken cancellationToken)
        {
            await _vaccineCommandService.DeleteAsync(request,cancellationToken);
            return Unit.Value;
        }
    }
}

