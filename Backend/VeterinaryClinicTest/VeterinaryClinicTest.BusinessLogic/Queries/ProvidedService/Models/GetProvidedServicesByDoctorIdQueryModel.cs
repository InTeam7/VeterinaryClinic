using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models
{
    public class GetProvidedServicesByDoctorIdQueryModel : IRequest<IList<ProvidedServiceListDto>>
    {
        public int Id { get; set; }
        public GetProvidedServicesByDoctorIdQueryModel(int id)
        {
            Id = id;
        }
    }
}

