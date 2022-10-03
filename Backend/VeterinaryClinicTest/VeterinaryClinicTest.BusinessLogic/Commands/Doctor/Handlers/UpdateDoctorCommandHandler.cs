using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Handlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommandModel,Unit>
    {
        private readonly IDoctorCommandsService _doctorCommandService;
        public UpdateDoctorCommandHandler(IDoctorCommandsService doctorCommandService)
        {
            _doctorCommandService = doctorCommandService;
        }

        public async Task<Unit> Handle(UpdateDoctorCommandModel request, CancellationToken cancellationToken)
        {
            await _doctorCommandService.UpdateAsync(request, cancellationToken);
            return Unit.Value;
        }
    }
}

