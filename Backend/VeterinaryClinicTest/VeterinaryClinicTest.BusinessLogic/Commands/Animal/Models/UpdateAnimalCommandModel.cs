using System;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models
{
    public class UpdateAnimalCommandModel : IRequest
    {
        public int Id { get;protected set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Specie Specie { get; set; }

        public string FileName { get; set; }

        public UpdateAnimalCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}

