using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models
{
    public class GetProvidedServicesQueryModel : IRequest<ProvidedServiceListDtoVM>
    {
        public GetProvidedServicesQueryModel()
        {
        }
    }
}

