using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Handlers
{
    public class GetVaccinesByTitleQueryHandler : IRequestHandler<GetVaccinesByTitleQueryModel,IList<VaccineListDto>>
    {
        private readonly IVaccineQueryService _vaccineQueryService;
        public GetVaccinesByTitleQueryHandler(IVaccineQueryService vaccineQueryService)
        {
            _vaccineQueryService = vaccineQueryService;
        }

        public async Task<IList<VaccineListDto>> Handle(GetVaccinesByTitleQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _vaccineQueryService.GetByTitleAsync(request.Title);
            return result;
        }
    }
}

