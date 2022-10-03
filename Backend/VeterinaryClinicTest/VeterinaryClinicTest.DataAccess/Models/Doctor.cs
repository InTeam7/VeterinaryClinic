using System;
using System.Collections.Generic;

namespace VeterinaryClinicTest.DataAccess.Models
{
    public class Doctor : BaseEntity
    {
        private readonly List<ProvidedService> _providedServices = new List<ProvidedService>();

        private readonly List<ClinicService> _services = new List<ClinicService>();

        private readonly List<DateTime> _busyTime = new List<DateTime>();

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; } = false;

        public string Speciality { get; set; }

        public ICollection<DateTime> BusyTime => _busyTime;

        public ICollection<ClinicService> Services => _services;

        public ICollection<ProvidedService> ProvidedServices => _providedServices;
    }
}

