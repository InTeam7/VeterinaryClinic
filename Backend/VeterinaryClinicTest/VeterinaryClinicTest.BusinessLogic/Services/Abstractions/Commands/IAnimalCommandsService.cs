using System;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands
{
    public interface IAnimalCommandsService
    {
        Task<int> AddAsync(AddAnimalCommandModel animalAdd, CancellationToken token);

        Task UpdateAsync(UpdateAnimalCommandModel animalUpdate, CancellationToken token);

       
       
    }
}

