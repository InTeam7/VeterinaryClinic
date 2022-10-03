using System;
using System.Collections.Generic;
using MediatR;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models
{
    public class AddDoctorCommandModel : IRequest<int>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Speciality { get; set; }

        public IList<int> ServiceIds { get; set; }


    }
}

