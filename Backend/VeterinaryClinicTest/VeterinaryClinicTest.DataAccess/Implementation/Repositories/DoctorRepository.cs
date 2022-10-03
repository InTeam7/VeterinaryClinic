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
    public class DoctorRepository : Repository<Doctor>,IDoctorRepository
    {
        private readonly IDBContext _context;
        public DoctorRepository(IDBContext contex) : base(contex)
        {
            _context = contex;
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
        }

        public async Task<IList<Doctor>> GetByNameAndEnsureExistAsync(string name)
        {
            var doctors = await _context
                .Doctors
                .Where(z => EF.Functions.Like(z.Name, "%" + name + "%"))
                .AsNoTracking()
                .ToListAsync();
            
            return doctors;
        }

        public override async Task<Doctor> GetAndEnsureExistAsync(int id)
        {
            var doctor = await _context
                .Doctors
                .Where(z => z.Id == id)
                .Include(z => z.Services)
                .Include(z => z.ProvidedServices)
                .FirstOrDefaultAsync();
            if(doctor == null)
            {
                throw new ClinicExceptions(ErrorCode.DoctorNotFound);
            }
            return doctor;
        }
    }
}

