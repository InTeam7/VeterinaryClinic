using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Abstractions.Repositories
{
    public interface IClinicServiceRepository : IRepository<ClinicService>
    {
        Task AddAsync(ClinicService service);
        Task<IList<ClinicService>> GetByTitleAndEnsureExistAsync(string title);
    }
}

