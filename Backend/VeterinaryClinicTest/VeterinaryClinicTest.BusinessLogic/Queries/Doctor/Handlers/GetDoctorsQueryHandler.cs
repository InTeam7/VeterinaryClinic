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
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQueryModel,IList<DoctorListDto>>
    {
        private readonly IDoctorQueryService _doctorQueryservice;
        public GetDoctorsQueryHandler(IDoctorQueryService doctorQueryService)
        {
            _doctorQueryservice = doctorQueryService;
        }

        public async Task<IList<DoctorListDto>> Handle(GetDoctorsQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _doctorQueryservice.GetAsync();
            return result;
        }
    }
}

