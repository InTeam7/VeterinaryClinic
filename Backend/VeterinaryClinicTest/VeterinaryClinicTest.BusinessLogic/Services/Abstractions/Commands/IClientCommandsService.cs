using System;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands
{
    public interface IClientCommandsService
    {
        Task<int> AddAsync(AddClientCommandModel clientAdd, CancellationToken token);

        Task UpdateAsync(UpdateClientCommandModel clientUpdate, CancellationToken token);

        
    }
}

