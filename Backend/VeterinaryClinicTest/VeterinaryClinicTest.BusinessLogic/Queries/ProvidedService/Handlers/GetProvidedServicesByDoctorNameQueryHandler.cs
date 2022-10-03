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
    public class GetProvidedServicesByDoctorNameQueryHandler : IRequestHandler<GetProvidedServicesByDoctorNameQueryModel,IList<ProvidedServiceListDto>>
    {
        private readonly IProvidedServicesQueryService _providedServiceQueryService;
        public GetProvidedServicesByDoctorNameQueryHandler(IProvidedServicesQueryService providedServicesQueryService)
        {
            _providedServiceQueryService = providedServicesQueryService;
        }

        public async Task<IList<ProvidedServiceListDto>> Handle(GetProvidedServicesByDoctorNameQueryModel request, CancellationToken cancellationToken)
        {
            var services = await _providedServiceQueryService.GetByDoctorNameAsync(request.Name);
            return services;

        }
    }
}

