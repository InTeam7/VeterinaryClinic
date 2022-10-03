using System;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands
{
    public interface IClinicServiceCommandsService
    {
        Task<int> AddAsync(AddClinicServiceCommandModel serviceModelAdd, CancellationToken token);

        Task UpdateAsync(UpdateClinicServiceCommandModel serviceModelUpdate, CancellationToken token);

        Task DeleteAsync(DeleteClinicServiceCommandModel serviceModelDelete, CancellationToken token);
    }
}

