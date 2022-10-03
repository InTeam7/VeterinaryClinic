using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Handlers
{
    public class UpdateVaccineCommandHandler : IRequestHandler<UpdateVaccineCommandModel, Unit>
    {
        private readonly IVaccineCommandsService _vaciineCommandService;

        public UpdateVaccineCommandHandler(IVaccineCommandsService vaccineCommandsService)
        {
            _vaciineCommandService = vaccineCommandsService;

        }

        public async Task<Unit> Handle(UpdateVaccineCommandModel request, CancellationToken cancellationToken)
        {
            await _vaciineCommandService.UpdateAsync(request,cancellationToken);
            return Unit.Value;
        }
    }
}

