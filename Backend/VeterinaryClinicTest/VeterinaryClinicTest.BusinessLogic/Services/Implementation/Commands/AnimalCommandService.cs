using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.Core.Extensions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands
{
    public class AnimalCommandService : IAnimalCommandsService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public AnimalCommandService(IAnimalRepository animalRepository,IClientRepository clientRepository,IMapper mapper)
        {
            _animalRepository = animalRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddAnimalCommandModel animalAdd, CancellationToken token)
        {
            var client = await _clientRepository.GetAndEnsureExistAsync(animalAdd.OwnerId);
            var animal = new Animal()
            {
                Name = animalAdd.Name,
                BirthDay = DateTime.Now.AddYears(animalAdd.Age * -1),
                Gender = animalAdd.Gender,
                Specie = animalAdd.Specie,
                PhotoFileName = animalAdd.FileName,
                OwnerId = client.Id
            };
            //animal.Vaccines.AddRange(_mapper.Map<ICollection<Vaccine>>(animalAdd.Vaccine));
            client.Animals.Add(animal);

            await _clientRepository.SaveChangesAsync(token);

            return animal.Id;

        }

        public async Task UpdateAsync(UpdateAnimalCommandModel animalUpdate, CancellationToken token)
        {
            var animal = await _animalRepository.GetAndEnsureExistAsync(animalUpdate.Id);

            animal.Name = animalUpdate.Name;
            animal.BirthDay = DateTime.Now.AddYears(animalUpdate.Age * -1);
            animal.Gender = animalUpdate.Gender;
            animal.Specie = animalUpdate.Specie;
            animal.PhotoFileName = animalUpdate.FileName;

            await _animalRepository.SaveChangesAsync(token);
        }

        
    }
}

