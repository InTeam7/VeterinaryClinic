using System;
using System.Collections.Generic;

namespace VeterinaryClinicTest.DataAccess.Models
{
    public class Client : BaseEntity
    { 
        private List<Animal> animals = new List<Animal>();

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal Purchases { get; set; }

        public ICollection<Animal> Animals => animals;

    }
}

