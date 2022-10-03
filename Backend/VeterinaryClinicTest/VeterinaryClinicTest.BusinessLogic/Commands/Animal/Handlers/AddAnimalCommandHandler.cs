using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Animal.Handlers
{
    public class AddAnimalCommandHandler : IRequestHandler<AddAnimalCommandModel,int>
    {
        private readonly IAnimalCommandsService _animalcommandService;
        public AddAnimalCommandHandler(IAnimalCommandsService animalCommandsService)
        {
            _animalcommandService = animalCommandsService;
        }

        public async Task<int> Handle(AddAnimalCommandModel request, CancellationToken cancellationToken)
        {
            var animalId = await _animalcommandService.AddAsync(request, cancellationToken);
            return animalId;
        }
    }
}

