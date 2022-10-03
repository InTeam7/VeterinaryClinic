using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Handlers
{
    public class GetAnimalsByOwnerIdQueryHandler :IRequestHandler<GetAnimalsByOwnerIdQueryModel,IList<AnimalListDto>>
    {
        private readonly IAnimalQueryService _animalQueryService;
        public GetAnimalsByOwnerIdQueryHandler(IAnimalQueryService animalQueryService)
        {
            _animalQueryService = animalQueryService;
        }

        public async Task<IList<AnimalListDto>> Handle(GetAnimalsByOwnerIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _animalQueryService.GetAnimalsByOwnerId(request);
            return result;
        }
    }
}

