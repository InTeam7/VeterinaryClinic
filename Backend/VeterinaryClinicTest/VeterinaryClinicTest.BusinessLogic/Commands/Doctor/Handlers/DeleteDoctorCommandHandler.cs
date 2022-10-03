using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Handlers
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommandModel,Unit>
    {
        private readonly IDoctorCommandsService _doctorCommandService;
        public DeleteDoctorCommandHandler(IDoctorCommandsService doctorCommandService)
        {
            _doctorCommandService = doctorCommandService;
        }

        public async Task<Unit> Handle(DeleteDoctorCommandModel request, CancellationToken cancellationToken)
        {
            await _doctorCommandService.DeleteAsync(request,cancellationToken);
            return Unit.Value;
        }
    }
}

