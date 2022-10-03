using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models
{
    public class GetAnimalsByOwnerIdQueryModel : IRequest<IList<AnimalListDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

       
    }
}

