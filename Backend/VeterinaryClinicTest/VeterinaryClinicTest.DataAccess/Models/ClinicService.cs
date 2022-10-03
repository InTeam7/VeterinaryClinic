using System;
using System.Collections.Generic;

namespace VeterinaryClinicTest.DataAccess.Models
{
    public class ClinicService : BaseEntity
    {
        private readonly List<Doctor> _doctors = new List<Doctor>();

        private readonly List<ProvidedService> _providedServices = new List<ProvidedService>();

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Doctor> Doctors => _doctors;

        public ICollection<ProvidedService> ProvidedServices => _providedServices;
    }
}

