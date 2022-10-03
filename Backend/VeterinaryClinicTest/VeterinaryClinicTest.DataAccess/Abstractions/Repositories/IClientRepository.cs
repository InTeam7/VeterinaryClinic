using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Abstractions.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task AddAsync(Client client);
        Task<IList<Client>> GetByPhoneNumberAndEnsureExistAsync(string phoneNumber);
    }
}

