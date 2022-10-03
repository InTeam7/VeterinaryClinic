using System;
using System.Collections.Generic;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class ClientListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IList<AnimalListDto> Animals { get; set; }

        //public IList<string> AnimalNames { get; set; }
    }
}

