using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries
{
    public class AnimalQueryService : IAnimalQueryService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;
        public AnimalQueryService(IAnimalRepository animalRepository,IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<IList<AnimalListDto>> GetAsync()
        {
            var animals = await _animalRepository.GetListAsync();
            return _mapper.Map<IList<AnimalListDto>>(animals);

        }

        public async Task<AnimalDto> GetByIdAsync(int id)
        {
            var animal = await _animalRepository.GetAndEnsureExistAsync(id);
            return _mapper.Map<AnimalDto>(animal);

        }

        public async Task<IList<AnimalListDto>> GetByNameAsync(string name)
        {
            var animals = await _animalRepository.GetByNameAndEnsureExistAsync(name);
            return _mapper.Map<IList<AnimalListDto>>(animals);
        }

        public async Task<IList<AnimalListDto>> GetAnimalsByOwnerId(GetAnimalsByOwnerIdQueryModel model)
        {
            var animals = await _animalRepository.GetAnimalListByOwnerId(model.Id);
            return _mapper.Map<IList<AnimalListDto>>(animals);
        }
    }
}

