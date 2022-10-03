using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries
{
    public class ClinicServiceQueryService : IClinicServiceQueryService
    {
        private readonly IMapper _mapper;
        private readonly IClinicServiceRepository _clinicServiceRepository;
        public ClinicServiceQueryService(IMapper mapper,IClinicServiceRepository clinicServiceRepository)
        {
            _clinicServiceRepository = clinicServiceRepository;
            _mapper = mapper;
        }

        public async Task<IList<ClinicServiceListDto>> GetAsync()
        {
            var services = await _clinicServiceRepository.GetListAsync();
            return _mapper.Map<IList<ClinicServiceListDto>>(services);
        }

        public async Task<ClinicServiceDto> GetByIdAsync(int id)
        {
            var service = await _clinicServiceRepository.GetAndEnsureExistAsync(id);
            return _mapper.Map<ClinicServiceDto>(service);
        }

        public async Task<IList<ClinicServiceListDto>> GetByTitleAsync(string title)
        {
            var services = await _clinicServiceRepository.GetByTitleAndEnsureExistAsync(title);
            return _mapper.Map<IList<ClinicServiceListDto>>(services.OrderByDescending(z=>z.Price).ToList());
        }
    }
}

