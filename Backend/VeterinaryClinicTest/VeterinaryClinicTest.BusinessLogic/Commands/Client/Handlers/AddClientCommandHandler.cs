using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Client.Handlers
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommandModel,int>
    {
        private readonly IClientCommandsService _clientCommandsService;
        public AddClientCommandHandler(IClientCommandsService clientCommandsService)
        {
            _clientCommandsService = clientCommandsService;
        }

        public async Task<int> Handle(AddClientCommandModel request, CancellationToken cancellationToken)
        {
            var result = await _clientCommandsService.AddAsync(request, cancellationToken);
            return result;
        }
    }
}

