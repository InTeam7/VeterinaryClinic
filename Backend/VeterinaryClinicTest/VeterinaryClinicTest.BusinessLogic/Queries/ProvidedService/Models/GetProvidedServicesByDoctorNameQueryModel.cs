using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models
{
    public class GetProvidedServicesByDoctorNameQueryModel : IRequest<IList<ProvidedServiceListDto>>
    {
        public string Name { get; set; }
        public GetProvidedServicesByDoctorNameQueryModel(string name)
        {
            Name = name;
        }
    }
}

