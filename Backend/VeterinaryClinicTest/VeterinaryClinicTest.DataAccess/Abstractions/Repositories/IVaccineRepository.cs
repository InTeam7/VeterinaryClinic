using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Abstractions.Repositories
{
    public interface IVaccineRepository : IRepository<Vaccine>
    {
        Task<int> AddAsync(Vaccine vaccine);
        Task<IList<Vaccine>> GetByTitleAndEnsureExistAsync(string title);
        Task<IList<Vaccine>> GetByCount();
    }
}

