using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries
{
    public class DoctorQueryService:IDoctorQueryService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorQueryService(IDoctorRepository doctorRepository,IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IList<DoctorListDto>> GetAsync()
        {
            var doctors = await _doctorRepository
                .GetQueryable()
                .Where(z=>z.IsDeleted!=true)
                .Include(z => z.Services)
                .ToListAsync();
                
            return _mapper.Map<IList<DoctorListDto>>(doctors);
        }

        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetAndEnsureExistAsync(id);
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<IList<DoctorListDto>> GetByNameAsync(string name)
        {
            var doctors = await _doctorRepository.GetByNameAndEnsureExistAsync(name);
            return _mapper.Map<IList<DoctorListDto>>(doctors);
        }
    }
}

