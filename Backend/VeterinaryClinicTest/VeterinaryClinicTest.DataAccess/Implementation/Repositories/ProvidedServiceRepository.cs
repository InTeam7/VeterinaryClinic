using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Implementation.Repositories
{
    public class ProvidedServiceRepository : Repository<ProvidedService>,IProvidedServiceRepository
    {
        private readonly IDBContext _context;
        public ProvidedServiceRepository(IDBContext context):base(context)
        {
            _context = context;
        }

        

        public async Task<IList<ProvidedService>> GetByDoctorNameAndEnsureExist(string name)
        {
            var services = await _context
                .ProvidedServices
                .Include(z => z.Animal)
                .Include(z => z.Doctor)
                .Include(z => z.Service)
                .Where(z => z.Doctor.Name.Contains(name))
                .AsNoTracking()
                .ToListAsync();
            
            return services;
        }

        public async Task<IList<ProvidedService>> GetByDoctorId(int id)
        {
            var services = await _context
                .ProvidedServices
                .Where(z => z.DoctorId == id)
                .Include(z => z.Animal)
                .ThenInclude(z=>z.Owner)
                .Include(z => z.Doctor)
                .Include(z => z.Service)
                .AsNoTracking()
                .ToListAsync();
            if (services == null)
            {
                throw new ClinicExceptions(ErrorCode.DoctorNotFound);
            }
            return services;

        }
        public override async Task<ProvidedService> GetAndEnsureExistAsync(int id)
        {
            var service = await _context
                .ProvidedServices
                .Where(z => z.Id == id)
                .Include(z => z.Animal)
                .ThenInclude(z=>z.Owner)
                .Include(z => z.Doctor)
                .Include(z => z.Service)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (service == null)
            {
                throw new ClinicExceptions(ErrorCode.ProvidedServiceNotFound);
            }
            
            return service;
        }

        public override async Task<IList<ProvidedService>> GetListAsync()
        {
            var services = await _context.ProvidedServices
                .Include(z => z.Animal)
                .Include(z => z.Doctor)
                .Include(z => z.Service)
                .AsNoTracking()
                .ToListAsync();
            return services;
        }
    }
}

