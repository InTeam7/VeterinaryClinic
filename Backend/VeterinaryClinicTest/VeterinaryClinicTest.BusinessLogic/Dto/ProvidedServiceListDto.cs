using System;
using System.Collections.Generic;
using System.Linq;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class ProvidedServiceListDto
    {
        public int Id { get; set; }

        public string AnimalName { get; set; }

        public string ServiceName { get; set; }

        public string DoctorName { get; set; }

        public decimal Price { get; set; }

        public decimal ServicePrice { get; set; }

        public decimal VaccinePrice { get; set; }

        public DateTime Date { get; set; }

        


    }
}

