using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Handlers
{
    public class GetVaccineByIdQueryHandler : IRequestHandler<GetVaccineByIdQueryModel,VaccineDto>
    {
        private readonly IVaccineQueryService _vaccineQueryService;

        public GetVaccineByIdQueryHandler(IVaccineQueryService vaccineQueryService)
        {
            _vaccineQueryService = vaccineQueryService;
        }

        public async Task<VaccineDto> Handle(GetVaccineByIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _vaccineQueryService.GetByIdAsync(request.Id);
            return result;
        }
    }
}

