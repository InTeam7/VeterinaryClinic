using System;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models
{
    public class GetVaccineByIdQueryModel : IRequest<VaccineDto>
    {
        public int Id { get; set; }

        public GetVaccineByIdQueryModel(int id)
        {
            Id = id;
        }
    }
}

