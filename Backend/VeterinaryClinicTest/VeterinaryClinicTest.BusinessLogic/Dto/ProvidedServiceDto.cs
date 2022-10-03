using System;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class ProvidedServiceDto
    {
        public int Id { get; set; }

        public string AnimalName { get; set; }

        public string ServiceName { get; set; }

        public string DoctorName { get; set; }

        public string DoctorPhoneNumber { get; set; }

        public string OwnerName { get; set; }

        public string OwnerPhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public Specie Specie { get; set; }

        public int AnimalAge { get; set; }

        public decimal Price { get; set; }

        public decimal ServicePrice { get; set; }

        public decimal VaccinePrice { get; set; }

        public int? VaccineId { get; set; }

        public DateTime Date { get; set; }

        public string Anamnesis { get; set; }

        public string Diagnosis { get; set; }
    }
}


