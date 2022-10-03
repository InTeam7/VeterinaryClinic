using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Handlers
{
    public class GetClinicServicesQueryHandler : IRequestHandler<GetClinicServicesQueryModel,IList<ClinicServiceListDto>>
    {
        private readonly IClinicServiceQueryService _clinicServiceQueryService;
        public GetClinicServicesQueryHandler(IClinicServiceQueryService clinicServiceQueryService)
        {
            _clinicServiceQueryService = clinicServiceQueryService;
        }

        async Task<IList<ClinicServiceListDto>> IRequestHandler<GetClinicServicesQueryModel, IList<ClinicServiceListDto>>.Handle(GetClinicServicesQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _clinicServiceQueryService.GetAsync();
            return result;
        }
    }
}

