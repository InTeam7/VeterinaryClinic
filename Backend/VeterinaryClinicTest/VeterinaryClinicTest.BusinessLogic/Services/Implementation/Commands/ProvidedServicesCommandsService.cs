using System;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands
{
    public class ProvidedServicesCommandsService : IProvidedServicesCommandsService
    {
        private readonly IProvidedServiceRepository _providedServiceRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IClinicServiceRepository _clinicServiceRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IVaccineRepository _vaccineRepository;

        public ProvidedServicesCommandsService(
            IProvidedServiceRepository provideServiceRepository,
            IAnimalRepository animalRepository,
            IClinicServiceRepository clinicServiceRepository,
            IDoctorRepository doctorRepository,
            IVaccineRepository vaccineRepository
            )
        {
            _providedServiceRepository = provideServiceRepository;
            _animalRepository = animalRepository;
            _clinicServiceRepository = clinicServiceRepository;
            _doctorRepository = doctorRepository;
            _vaccineRepository = vaccineRepository;
        }

        public async Task<int> AddAsync(AddProvidedServiceCommandModel providedServiceAdd, CancellationToken token)
        {
            var animal = await _animalRepository.GetAndEnsureExistAsync(providedServiceAdd.AnimalId);
            var service = await _clinicServiceRepository.GetAndEnsureExistAsync(providedServiceAdd.ServiceId);
            var client = animal.Owner;
            client.Purchases += service.Price;
            var doctor = await _doctorRepository.GetAndEnsureExistAsync(providedServiceAdd.DoctorId);
            var newProvidedService = new ProvidedService()
            {
                Animal = animal,
                AnimalId = providedServiceAdd.AnimalId,
                Service = service,
                ServiceId = providedServiceAdd.ServiceId,
                Doctor = doctor,
                DoctorId = providedServiceAdd.DoctorId,
                Date = DateTime.Now,
                Anamnesis = providedServiceAdd.Ananmnesis,
                Diagnosis = providedServiceAdd.Diagnosis,
                ServicePrice = service.Price,
                VaccineId = null

            };
            if (providedServiceAdd.VaccineId != null)
            {
                var vaccine = await _vaccineRepository.GetAndEnsureExistAsync(providedServiceAdd.VaccineId.Value);
                if (vaccine.Count > 0)
                {
                    client.Purchases += vaccine.Price;
                    vaccine.Count--;
                    animal.Vaccines.Add(vaccine);
                    newProvidedService.VaccinePrice = vaccine.Price;
                    newProvidedService.VaccineId = providedServiceAdd.VaccineId;
                }
            }
            
            animal.ProvidedServices.Add(newProvidedService);
            
            await _animalRepository.SaveChangesAsync(token);
            return newProvidedService.Id;
        }

        

        
    }
}

