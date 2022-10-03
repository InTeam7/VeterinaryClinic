using System;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models
{
    public class GetProvidedServiceByIdQueryModel:IRequest<ProvidedServiceDto>
    {
        public int Id { get; set; }
        public GetProvidedServiceByIdQueryModel(int id)
        {
            Id = id;
        }
    }
}

