using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Handlers
{
    public class GetClinicServiceByIdQueryHandler : IRequestHandler<GetClinicServiceByIdQueryModel,ClinicServiceDto>
    {

        private readonly IClinicServiceQueryService _clinicServiceQueryService;
        public GetClinicServiceByIdQueryHandler(IClinicServiceQueryService clinicServiceQueryService)
        {
            _clinicServiceQueryService = clinicServiceQueryService;
        }

        public async Task<ClinicServiceDto> Handle(GetClinicServiceByIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _clinicServiceQueryService.GetByIdAsync(request.Id);
            return result;
        }
    }
}

