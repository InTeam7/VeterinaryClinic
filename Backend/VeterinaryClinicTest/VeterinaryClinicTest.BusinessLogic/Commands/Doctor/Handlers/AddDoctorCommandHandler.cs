using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Handlers
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommandModel,int>
    {
        private readonly IDoctorCommandsService _doctorCommandService;
        public AddDoctorCommandHandler(IDoctorCommandsService doctorCommandService)
        {
            _doctorCommandService = doctorCommandService;
        }

        public async Task<int> Handle(AddDoctorCommandModel request, CancellationToken cancellationToken)
        {
            var result = await _doctorCommandService.AddAsync(request, cancellationToken);
            return result;
        }
    }
}

