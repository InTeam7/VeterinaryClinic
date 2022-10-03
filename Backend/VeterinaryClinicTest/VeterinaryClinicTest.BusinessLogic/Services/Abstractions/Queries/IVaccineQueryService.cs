using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries
{
    public interface IVaccineQueryService
    {
        Task<IList<VaccineListDto>> GetAsync();

        Task<IList<VaccineListDto>> GetByCountAsync();

        Task<VaccineDto> GetByIdAsync(int id);

        Task<IList<VaccineListDto>> GetByTitleAsync(string title);
    }
}

