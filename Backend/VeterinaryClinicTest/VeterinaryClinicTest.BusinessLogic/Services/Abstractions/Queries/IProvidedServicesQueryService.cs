using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries
{
    public interface IProvidedServicesQueryService
    {
        Task<ProvidedServiceListDtoVM> GetAsync();

        Task<ProvidedServiceDto> GetByIdAsync(int id);

        Task<IList<ProvidedServiceListDto>> GetByDoctorNameAsync(string name);

        Task<IList<ProvidedServiceListDto>> GetByDoctorIdAsync(int id);
    }
}

