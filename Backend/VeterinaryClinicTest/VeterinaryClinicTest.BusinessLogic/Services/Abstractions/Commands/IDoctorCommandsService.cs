using System;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands
{
    public interface IDoctorCommandsService
    {
        Task<int> AddAsync(AddDoctorCommandModel doctorAdd, CancellationToken token);

        Task UpdateAsync(UpdateDoctorCommandModel doctorUpdate, CancellationToken token);

        Task DeleteAsync(DeleteDoctorCommandModel doctorDelete, CancellationToken token);
    }
}

