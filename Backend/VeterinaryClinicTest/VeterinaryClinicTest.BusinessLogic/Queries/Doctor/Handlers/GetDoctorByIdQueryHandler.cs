using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Handlers
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQueryModel,DoctorDto>
    {
        private readonly IDoctorQueryService _doctorQueryService;
        public GetDoctorByIdQueryHandler(IDoctorQueryService doctorQueryService)
        {
            _doctorQueryService = doctorQueryService;
        }

        public async Task<DoctorDto> Handle(GetDoctorByIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _doctorQueryService.GetByIdAsync(request.Id);
            return result;
        }
    }
}

