using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Handlers
{
    public class AddVaccineCommandHandler: IRequestHandler<AddVaccineCommandModel, int>
    {
        private readonly IVaccineCommandsService _vaccineCommandsService;

        public AddVaccineCommandHandler(IVaccineCommandsService vaccineCommandsService)
        {
            _vaccineCommandsService = vaccineCommandsService;
        }
        
        public async Task<int> Handle(AddVaccineCommandModel request, CancellationToken cancellationToken)
        {
            var vaccineId = await _vaccineCommandsService.AddAsync(request, cancellationToken);
            return vaccineId;
        }
    }
}

