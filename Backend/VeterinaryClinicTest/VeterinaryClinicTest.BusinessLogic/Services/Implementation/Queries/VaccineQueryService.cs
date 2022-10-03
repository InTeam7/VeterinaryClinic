using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries
{
    public class VaccineQueryService : IVaccineQueryService
    {
        private readonly IVaccineRepository _vaccineRepository;
        private readonly IMapper _mapper;
        public VaccineQueryService(IVaccineRepository vaccineRepository,IMapper mapper)
        {
            _vaccineRepository = vaccineRepository;
            _mapper = mapper;
        }

        public async Task<IList<VaccineListDto>> GetAsync()
        {
            var vaccines = await _vaccineRepository.GetListAsync();
            var sortedVaccines = vaccines
                .OrderByDescending(z => z.Count)
                .Where(z=>z.IsDeleted!=true)
                .ToList();
            return _mapper.Map<List<VaccineListDto>>(sortedVaccines);

        }

        public async Task<IList<VaccineListDto>> GetByCountAsync()
        {
            var vaccines = await _vaccineRepository.GetByCount();
            return _mapper.Map<IList<VaccineListDto>>(vaccines);
        }

        public async Task<VaccineDto> GetByIdAsync(int id)
        {
            var vaccine = await _vaccineRepository.GetAndEnsureExistAsync(id);
            return _mapper.Map<VaccineDto>(vaccine);
        }

        public async Task<IList<VaccineListDto>> GetByTitleAsync(string title)
        {
            var vaccines = await _vaccineRepository.GetByTitleAndEnsureExistAsync(title);
            return _mapper.Map<List<VaccineListDto>>(vaccines);

        }
    }
}

