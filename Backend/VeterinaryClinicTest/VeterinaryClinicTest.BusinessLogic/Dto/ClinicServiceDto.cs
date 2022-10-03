using System;
using System.Collections.Generic;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class ClinicServiceDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public List<DoctorListDto> Doctors { get; set; }

        public List<ProvidedServiceListDto> ProvidedServices { get; set; }
    }
}

