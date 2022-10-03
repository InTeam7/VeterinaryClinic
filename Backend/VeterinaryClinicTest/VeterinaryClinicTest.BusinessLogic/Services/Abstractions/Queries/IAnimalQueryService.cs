using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries
{
    public interface IAnimalQueryService
    {
        Task<IList<AnimalListDto>> GetAsync();

        Task<AnimalDto> GetByIdAsync(int id);

        Task<IList<AnimalListDto>> GetByNameAsync(string name);

        Task<IList<AnimalListDto>> GetAnimalsByOwnerId(GetAnimalsByOwnerIdQueryModel model);
    }
}

