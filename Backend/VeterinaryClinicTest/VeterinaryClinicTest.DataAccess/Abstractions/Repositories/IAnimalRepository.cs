using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Abstractions.Repositories
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IList<Animal>> GetByNameAndEnsureExistAsync(string name);

        Task<ICollection<Animal>> GetAnimalListByOwnerId(int id);
    }
}

