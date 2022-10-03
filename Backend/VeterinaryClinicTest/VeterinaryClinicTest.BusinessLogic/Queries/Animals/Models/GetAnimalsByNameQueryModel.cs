using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models
{
    public class GetAnimalsByNameQueryModel : IRequest<IList<AnimalListDto>>
    {
        public string Name { get; set; }
        public GetAnimalsByNameQueryModel(string name)
        {
            Name = name;
        }
    }
}

