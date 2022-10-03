using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.Implementation.Repositories
{
    
    public class AnimalRepository : Repository<Animal>,IAnimalRepository
    {
        private readonly IDBContext _context;
        public AnimalRepository(IDBContext context):base(context)
        {
            _context = context;
        }

        public override async Task<Animal> GetAndEnsureExistAsync(int id)
        {
            var animal = await _context
                .Animals
                .Where(z => z.Id == id)
                .Include(z=>z.Owner)
                .Include(z => z.ProvidedServices)
                .ThenInclude(z=>z.Service)
                .ThenInclude(z=>z.Doctors)
                .Include(z => z.Vaccines)
                .FirstOrDefaultAsync();
            if (animal == null)
            {
                throw new ClinicExceptions(ErrorCode.AnimalNotFound);
            }
            return animal;
        }

        public async Task<IList<Animal>> GetByNameAndEnsureExistAsync(string name)
        {
            var animals = await _context
                .Animals
                .Where(z => EF.Functions.Like(z.Name, "%" + name + "%"))
                .AsNoTracking()
                .ToListAsync();
            
            return animals;
        }

        public async override Task<IList<Animal>> GetListAsync()
        {
            var animals = await _context
                .Animals
                .AsNoTracking()
                .ToListAsync();
            return animals;
        }

        public async Task<ICollection<Animal>> GetAnimalListByOwnerId(int id)
        {
            var client = await _context
                .Clients
                .Where(z => z.Id == id)
                .Include(z => z.Animals)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            var animals = client.Animals;
            return animals;

        }

    }
}

