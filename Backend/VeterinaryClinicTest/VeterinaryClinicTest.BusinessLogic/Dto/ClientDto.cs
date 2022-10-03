using System;
using System.Collections.Generic;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public IList<AnimalDto> Animals { get; set; }

        public decimal Purchases { get; set; }
    }
}

