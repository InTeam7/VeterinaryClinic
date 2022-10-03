using System;
using System.Collections.Generic;
using System.Linq;
using VeterinaryClinicTest.DataAccess.Enums;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class AnimalDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Specie Specie { get; set; }

        public IList<string> GenderValues { get; set; } = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(v => v.ToString())
                .ToList();

        public IList<string> SpecieValues { get; set; } = Enum.GetValues(typeof(Specie))
                .Cast<Specie>()
                .Select(v => v.ToString())
                .ToList();

        public string PhotoFileName { get; set; }

        public int OwnerId { get; set; }

        public string OwnerName { get; set; }

        public ICollection<ProvidedServiceDto> ProviderServices { get; set; }

        public ICollection<Vaccine> Vaccines { get; set; }


    }
}

