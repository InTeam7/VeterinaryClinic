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
    public class GetProvidedServicesByDoctorIdQueryHandler:IRequestHandler<GetProvidedServicesByDoctorIdQueryModel,IList<ProvidedServiceListDto>>
    {
        private readonly IProvidedServicesQueryService _providedServicesQueryService;
        public GetProvidedServicesByDoctorIdQueryHandler(IProvidedServicesQueryService providedServicesQueryService)
        {
            _providedServicesQueryService = providedServicesQueryService;
        }

        public async Task<IList<ProvidedServiceListDto>> Handle(GetProvidedServicesByDoctorIdQueryModel request, CancellationToken cancellationToken)
        {
            var services = await _providedServicesQueryService.GetByDoctorIdAsync(request.Id);
            return services;
        }
    }
}

