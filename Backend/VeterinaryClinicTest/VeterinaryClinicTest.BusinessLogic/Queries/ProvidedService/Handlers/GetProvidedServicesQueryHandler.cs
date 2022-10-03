using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Handlers
{
    public class GetProvidedServicesQueryHandler : IRequestHandler<GetProvidedServicesQueryModel, ProvidedServiceListDtoVM>
    {
        private readonly IProvidedServicesQueryService _providedServiceQueryService;
        public GetProvidedServicesQueryHandler(IProvidedServicesQueryService providedServicesQueryService)
        {
            _providedServiceQueryService = providedServicesQueryService;
        }

        public async Task<ProvidedServiceListDtoVM> Handle(GetProvidedServicesQueryModel request, CancellationToken cancellationToken)
        {
            var services = await _providedServiceQueryService.GetAsync();
            return services;
        }

    }
}

