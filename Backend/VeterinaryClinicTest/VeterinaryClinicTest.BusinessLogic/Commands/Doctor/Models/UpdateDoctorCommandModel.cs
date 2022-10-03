using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models
{
    public class UpdateDoctorCommandModel : IRequest
    {
        public int Id { get;protected set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Speciality { get; set; }

        public IList<int> ServiceIds { get; set; }

        public UpdateDoctorCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }


    }
}

