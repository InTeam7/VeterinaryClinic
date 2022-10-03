using System;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class AnimalListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Specie Specie { get; set; }

        public string FileName { get; set; }
    }
}

