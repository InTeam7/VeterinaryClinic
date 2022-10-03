using System;
using System.Collections;

namespace VeterinaryClinicTest.DataAccess.Models
{
    public class ProvidedService : BaseEntity
    {
        public Animal Animal { get; set; }

        public int AnimalId { get; set; }

        public ClinicService Service { get; set; }

        public int ServiceId { get; set; }

        public Doctor Doctor { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public decimal ServicePrice { get; set; }

        public decimal VaccinePrice { get; set; }

        public int? VaccineId { get; set; }

        public string  Anamnesis { get; set; }

        public string Diagnosis { get; set; }

    }
}

