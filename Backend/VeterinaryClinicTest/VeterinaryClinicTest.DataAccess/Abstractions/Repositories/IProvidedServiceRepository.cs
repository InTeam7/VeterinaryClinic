using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Abstractions.Repositories
{
    public interface IProvidedServiceRepository : IRepository<ProvidedService>
    {
        Task<IList<ProvidedService>> GetByDoctorNameAndEnsureExist(string name);

        Task<IList<ProvidedService>> GetByDoctorId(int id);
    }
}

