using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Handlers
{
    public class GetAnimalByNameQueryHandler :IRequestHandler<GetAnimalsByNameQueryModel,IList<AnimalListDto>>
    {
        private readonly IAnimalQueryService _animalQueryService;
        public GetAnimalByNameQueryHandler(IAnimalQueryService animalQueryService)
        {
            _animalQueryService = animalQueryService;
        }

        public async Task<IList<AnimalListDto>> Handle(GetAnimalsByNameQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _animalQueryService.GetByNameAsync(request.Name);
            return result;
        }
    }
}

