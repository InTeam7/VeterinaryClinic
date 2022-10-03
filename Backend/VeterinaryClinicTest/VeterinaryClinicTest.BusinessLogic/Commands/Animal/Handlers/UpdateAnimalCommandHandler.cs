using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Animal.Handlers
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommandModel,Unit>
    {
        private readonly IAnimalCommandsService _animalcommandService;
        public UpdateAnimalCommandHandler(IAnimalCommandsService animalCommandsService)
        {
            _animalcommandService = animalCommandsService;
        }

        public async Task<Unit> Handle(UpdateAnimalCommandModel request, CancellationToken cancellationToken)
        {
            await _animalcommandService.UpdateAsync(request, cancellationToken);
            return Unit.Value;
        }
    }
}

