using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Client.Handlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommandModel,Unit>
    {
        private readonly IClientCommandsService _clientCommandsService;
        public UpdateClientCommandHandler(IClientCommandsService clientCommandsService)
        {
            _clientCommandsService = clientCommandsService;
        }

        public async Task<Unit> Handle(UpdateClientCommandModel request, CancellationToken cancellationToken)
        {
            await _clientCommandsService.UpdateAsync(request, cancellationToken);
            return Unit.Value;
        }
    }
}

