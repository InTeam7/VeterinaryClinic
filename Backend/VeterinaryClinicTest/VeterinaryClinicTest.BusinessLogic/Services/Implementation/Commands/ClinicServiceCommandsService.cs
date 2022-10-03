using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands
{
    public class ClinicServiceCommandsService : IClinicServiceCommandsService
    {
        private readonly IClinicServiceRepository _clinicServiceRepository;
        private readonly IDoctorRepository _doctorRepository;
        public ClinicServiceCommandsService(IClinicServiceRepository clinicServiceRepository,IDoctorRepository doctorRepository)
        {
            _clinicServiceRepository = clinicServiceRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<int> AddAsync(AddClinicServiceCommandModel serviceModelAdd, CancellationToken token)
        {
            
            var service = new ClinicService()
            {
                Title = serviceModelAdd.Title,
                Description = serviceModelAdd.Description,
                Price = serviceModelAdd.Price

            };
            foreach (var id in serviceModelAdd.DoctorIds)
            {
                var doctor = await _doctorRepository.GetAndEnsureExistAsync(id);
                service.Doctors.Add(doctor);
            }
            await _clinicServiceRepository.AddAsync(service);
            await _clinicServiceRepository.SaveChangesAsync(token);
            return service.Id;

        }

        public async Task DeleteAsync(DeleteClinicServiceCommandModel serviceModelDelete, CancellationToken token)
        {
            var service = await _clinicServiceRepository.GetAndEnsureExistAsync(serviceModelDelete.Id);
            service.IsDeleted = true;
            await _clinicServiceRepository.SaveChangesAsync(token);

        }

        public async Task UpdateAsync(UpdateClinicServiceCommandModel serviceModelUpdate, CancellationToken token)
        {
            var service = await _clinicServiceRepository.GetAndEnsureExistAsync(serviceModelUpdate.Id);
            service.Title = serviceModelUpdate.Title;
            service.Description = serviceModelUpdate.Title;
            service.Price = serviceModelUpdate.Price;
            service.IsDeleted = false;
            var doctorList = new List<Doctor>();
            foreach (var id in serviceModelUpdate.DoctorIds)
            {
                var doctor = await _doctorRepository.GetAndEnsureExistAsync(id);
                doctorList.Add(doctor);
            }
            var isEqual = Enumerable.SequenceEqual(service.Doctors.OrderBy(z => z.Id), doctorList.OrderBy(z => z.Id));
            if (!isEqual)
            {
                service.Doctors.Clear();
                foreach (var doctor in doctorList)
                {
                    service.Doctors.Add(doctor);
                }
            }
            await _clinicServiceRepository.SaveChangesAsync(token);
        }
    }
}

