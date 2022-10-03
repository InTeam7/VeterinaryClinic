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
    public class VaccineRepository : Repository<Vaccine>,IVaccineRepository
    {
        private readonly IDBContext _context;
        public VaccineRepository(IDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Vaccine vaccine)
        {
            await _context.Vaccines.AddAsync(vaccine);
            return vaccine.Id;
        }

        public async Task<IList<Vaccine>> GetByCount()
        {
            var vaccines = await _context
                .Vaccines
                .Where(z => z.Count > 0)
                .Where(z=>z.IsDeleted!=true)
                .ToListAsync();
            return vaccines;
        }
        public override async Task<Vaccine> GetAndEnsureExistAsync(int id)
        {
            var vaccine = await _context
                .Vaccines
                .Where(z => z.Id == id)
                .FirstOrDefaultAsync();
            if (vaccine == null)
            {
                throw new ClinicExceptions(ErrorCode.VaccineNotFound);
            }
            return vaccine;

        }

        public async Task<IList<Vaccine>> GetByTitleAndEnsureExistAsync(string title)
        {
            var vaccines = await _context
                .Vaccines
                .Where(z => EF.Functions.Like(z.Title,"%"+title+"%"))
                .AsNoTracking()
                .ToListAsync();
    
            return vaccines;
        }
    }
}

