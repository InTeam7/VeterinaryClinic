using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Http;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models
{
    public class AddAnimalCommandModel : IRequest<int>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Specie Specie { get; set; }

        public int OwnerId { get; set; }

        public string FileName { get;  set; }

        

    }
}

