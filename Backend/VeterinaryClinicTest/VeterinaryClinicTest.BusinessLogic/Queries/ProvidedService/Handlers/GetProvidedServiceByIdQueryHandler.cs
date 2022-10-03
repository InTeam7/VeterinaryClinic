using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Handlers
{
    public class GetProvidedServiceByIdQueryHandler:IRequestHandler<GetProvidedServiceByIdQueryModel,ProvidedServiceDto>
    {
        private readonly IProvidedServicesQueryService _providedServiceQueryservice;
        public GetProvidedServiceByIdQueryHandler(IProvidedServicesQueryService providedServicesQueryService)
        {
            _providedServiceQueryservice = providedServicesQueryService;
        }

        public async Task<ProvidedServiceDto> Handle(GetProvidedServiceByIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _providedServiceQueryservice.GetByIdAsync(request.Id);
            return result;
        }
    }
}

