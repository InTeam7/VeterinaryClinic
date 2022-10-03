using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries
{
    public interface IClinicServiceQueryService
    {
        Task<IList<ClinicServiceListDto>> GetAsync();

        Task<ClinicServiceDto> GetByIdAsync(int id);

        Task<IList<ClinicServiceListDto>> GetByTitleAsync(string title);
    }
}

