using System;
using System.Collections.Generic;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Speciality { get; set; }

        public bool IsDeleted { get; set; }

        public IList<ClinicServiceListDto> Services { get; set; }

        public IList<ProvidedServiceDto> ProvidedServices { get; set; }
    }
}

