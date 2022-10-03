using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands
{
    public interface IVaccineCommandsService
    {
        Task<int> AddAsync(AddVaccineCommandModel vaccineModelAdd,CancellationToken token);

        Task UpdateAsync(UpdateVaccineCommandModel vaccineModelUpdate,CancellationToken token);

        Task DeleteAsync(DeleteVaccineCommandModel vaccineModelDelete,CancellationToken token);
    }
}

