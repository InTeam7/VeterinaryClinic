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
    public class ClinicServiceRepository : Repository<ClinicService>, IClinicServiceRepository
    {
        private readonly IDBContext _context;
        public ClinicServiceRepository(IDBContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IList<ClinicService>> GetListAsync()
        {
            var services = await _context
                .ClinicServices
                .Where(z=>z.IsDeleted != true)
                .Include(z => z.Doctors)
                .Where(z=>z.Doctors
                    .Where(z=>z.IsDeleted != true)
                    .Count() != 0)
                .AsNoTracking()
                .ToListAsync();

            return services;

        }

        public async Task AddAsync(ClinicService clinicService)
        {
            await _context.ClinicServices.AddAsync(clinicService);
        }

        public async Task<IList<ClinicService>> GetByTitleAndEnsureExistAsync(string title)
        {
            var services = await _context
                .ClinicServices
                .Where(z => EF.Functions.Like(z.Title, "%" + title + "%"))
                .AsNoTracking()
                .ToListAsync();
            
            return services;
        }

        public override async Task<ClinicService> GetAndEnsureExistAsync(int id)
        {
            var service = await _context
                .ClinicServices
                .Where(z => z.Id == id)
                .Include(z => z.Doctors)
                .Include(z=>z.ProvidedServices)
                    .ThenInclude(z=>z.Animal)
                .Include(z => z.ProvidedServices)
                    .ThenInclude(z => z.Doctor)
                .FirstOrDefaultAsync();
            if (service == null)
            {
                throw new ClinicExceptions(ErrorCode.ServiceNotFound);
            }

            return service;
        }
    }
}

