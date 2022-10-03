using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models
{
    public class GetDoctorsByNameQueryModel : IRequest<IList<DoctorListDto>>
    {
        public string Name { get; set; }
        public GetDoctorsByNameQueryModel(string name)
        {
            Name = name;
        }
    }
}

