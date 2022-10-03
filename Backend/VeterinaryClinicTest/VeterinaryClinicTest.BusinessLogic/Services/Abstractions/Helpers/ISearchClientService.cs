using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Helpers
{
    public interface ISearchClientService
    {
        Task<IList<ClientListDto>> Search(IEnumerable<Client> clients,string searchString);
    }
}

