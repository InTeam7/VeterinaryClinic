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
    public class GetClinicByTitleQueryHandler :IRequestHandler<GetClinicServicesByTitleQueryModel,IList<ClinicServiceListDto>>
    {
        private readonly IClinicServiceQueryService _clinicServiceQueryService;
        public GetClinicByTitleQueryHandler(IClinicServiceQueryService clinicServiceQueryService)
        {
            _clinicServiceQueryService = clinicServiceQueryService;
        }

        public async Task<IList<ClinicServiceListDto>> Handle(GetClinicServicesByTitleQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _clinicServiceQueryService.GetByTitleAsync(request.Title);
            return result;
        }
    }
}

