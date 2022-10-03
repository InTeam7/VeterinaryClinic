using System;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models
{
    public class GetAnimalByIdQueryModel : IRequest<AnimalDto>
    {
        public int Id { get; set; }
        public GetAnimalByIdQueryModel(int id)
        {
            Id = id;
        }
    }
}

