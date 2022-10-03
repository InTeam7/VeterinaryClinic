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
    public class GetAnimalQueryHandler : IRequestHandler<GetAnimalsQueryModel, IList<AnimalListDto>>
    {
        private readonly IAnimalQueryService _animalQueryService;
        public GetAnimalQueryHandler(IAnimalQueryService animalQueryService)
        {
            _animalQueryService = animalQueryService;
        }

        public async Task<IList<AnimalListDto>> Handle(GetAnimalsQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _animalQueryService.GetAsync();
            return result;
        }
    }
}

