using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries
{
    public interface IDoctorQueryService
    {
        Task<IList<DoctorListDto>> GetAsync();

        Task<DoctorDto> GetByIdAsync(int id);

        Task<IList<DoctorListDto>> GetByNameAsync(string name);
    
    }
}

