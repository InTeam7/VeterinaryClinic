using System;
using System.Collections.Generic;
using System.Linq;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class ProvidedServiceListDtoVM
    {
        public IList<ProvidedServiceListDto> ProvidedServices { get; set; }

        public IList<string> GenderValues { get; set; } = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(v => v.ToString())
                .ToList();

        public IList<string> SpecieValues { get; set; } = Enum.GetValues(typeof(Specie))
                .Cast<Specie>()
                .Select(v => v.ToString())
                .ToList();
    }
}

