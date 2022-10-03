using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Handlers
{
    public class GetDoctorByNameQueryHandler : IRequestHandler<GetDoctorsByNameQueryModel,IList<DoctorListDto>>
    {
        private readonly IDoctorQueryService _doctorQueryService;
        public GetDoctorByNameQueryHandler(IDoctorQueryService doctorQueryService)
        {
            _doctorQueryService = doctorQueryService;
        }

        public async Task<IList<DoctorListDto>> Handle(GetDoctorsByNameQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _doctorQueryService.GetByNameAsync(request.Name);
            return result;
        }
    }
}

