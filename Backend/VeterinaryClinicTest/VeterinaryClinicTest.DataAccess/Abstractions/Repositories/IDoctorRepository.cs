using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Abstractions.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task AddAsync(Doctor doctor);
        Task<IList<Doctor>> GetByNameAndEnsureExistAsync(string name);
    }
}

