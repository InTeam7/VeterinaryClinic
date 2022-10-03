using System;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models
{
    public class GetDoctorByIdQueryModel:IRequest<DoctorDto>
    {
        public int Id { get; set; }
        public GetDoctorByIdQueryModel(int id)
        {
            Id = id;
        }
    }
}

