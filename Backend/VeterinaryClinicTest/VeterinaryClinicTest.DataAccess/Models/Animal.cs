using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.DataAccess.Models
{
    public class Animal : BaseEntity
    {
        private readonly List<ProvidedService> _providedServices = new List<ProvidedService>();

        private readonly List<Vaccine> _vaccines = new List<Vaccine>();

        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }

        public Gender Gender { get; set; }

        public Specie Specie { get; set; }

        public string PhotoFileName { get; set; }

        public Client Owner { get; set; }

        public int OwnerId { get; set; }

        public ICollection<ProvidedService> ProvidedServices => _providedServices;

        public List<Vaccine> Vaccines => _vaccines;
    }
    
}

