using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Implementation.Repositories
{
    public class ClientRepository : Repository<Client>,IClientRepository
    {
        private readonly IDBContext _context;
        public ClientRepository(IDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<IList<Client>> GetByPhoneNumberAndEnsureExistAsync(string phoneNumber)
        {
            SqlParameter param = new SqlParameter("@searchString", "%"+phoneNumber+"%");
            var clients = await _context
                .Clients
                .FromSqlRaw("SELECT * FROM Clients WHERE PhoneNumber LIKE @searchString",param)
                .AsNoTracking()
                .ToListAsync();

            return clients;
            
        }

        
        public override async Task<Client> GetAndEnsureExistAsync(int id)
        {
            var client = await _context
                .Clients
                .Where(z => z.Id == id)
                .Include(z=>z.Animals)
                .ThenInclude(z => z.ProvidedServices)
                .ThenInclude(z=>z.Doctor)
                .ThenInclude(z=>z.Services)
                .FirstOrDefaultAsync();

            if (client == null)
            {
                throw new ClinicExceptions(ErrorCode.ClientNotFound);
            }
            return client;
        }
        public override async Task<IList<Client>> GetListAsync()
        {
            var clients = await _context
                .Clients
                .Include(z=>z.Animals)
                .AsNoTracking()
                .ToListAsync();
            return clients;

        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }
    }
}

