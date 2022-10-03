using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Handlers
{
    public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQueryModel, AnimalDto>
    {
        private readonly IAnimalQueryService _animalQueryService;
        public GetAnimalByIdQueryHandler(IAnimalQueryService animalQueryService) 
        {
            _animalQueryService = animalQueryService;
        }

        public async Task<AnimalDto> Handle(GetAnimalByIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _animalQueryService.GetByIdAsync(request.Id);
            return result;
        }
    }
}

