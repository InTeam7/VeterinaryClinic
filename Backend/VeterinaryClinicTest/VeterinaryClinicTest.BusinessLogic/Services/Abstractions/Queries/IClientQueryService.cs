using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries
{
    public interface IClientQueryService
    {
        Task<IList<ClientListDto>> GetAsync();

        Task<ClientDto> GetByIdAsync(int id);

        Task<IList<ClientListDto>> GetByPhoneNumberAndName(string searchString);
    }
}

