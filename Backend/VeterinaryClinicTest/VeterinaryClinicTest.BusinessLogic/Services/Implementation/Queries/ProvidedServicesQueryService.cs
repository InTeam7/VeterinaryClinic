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
    public class ProvidedServicesQueryService : IProvidedServicesQueryService
    {
        private readonly IProvidedServiceRepository _providedServiceRepository;
        private readonly IMapper _mapper;
        public ProvidedServicesQueryService(IProvidedServiceRepository provideServiceRepository,IMapper mapper)
        {
            _providedServiceRepository = provideServiceRepository;
            _mapper = mapper;
        }

        public async Task<ProvidedServiceDto> GetByIdAsync(int id)
        {
            var service = await _providedServiceRepository.GetAndEnsureExistAsync(id);
            return _mapper.Map<ProvidedServiceDto>(service);
        }

        public async Task<ProvidedServiceListDtoVM> GetAsync()
        {
            var services = await _providedServiceRepository.GetListAsync();
            var dtoServices =  _mapper.Map<IList<ProvidedServiceListDto>>(services.OrderByDescending(z=>z.Date).ToList());
            return new ProvidedServiceListDtoVM() { ProvidedServices = dtoServices };
        }

        public async Task<IList<ProvidedServiceListDto>> GetByDoctorNameAsync(string name)
        {
            var services = await _providedServiceRepository.GetByDoctorNameAndEnsureExist(name);
            return _mapper.Map<IList<ProvidedServiceListDto>>(services);

        }
        public async Task<IList<ProvidedServiceListDto>> GetByDoctorIdAsync(int id)
        {
            var services = await _providedServiceRepository.GetByDoctorId(id);
            return _mapper.Map<IList<ProvidedServiceListDto>>(services);
        }
    }
}

