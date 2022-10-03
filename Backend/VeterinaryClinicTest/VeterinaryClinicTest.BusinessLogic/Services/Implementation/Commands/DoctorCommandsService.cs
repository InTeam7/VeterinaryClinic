using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands
{
    public class DoctorCommandsService : IDoctorCommandsService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IClinicServiceRepository _clinicServiceRepository;
        public DoctorCommandsService(IDoctorRepository doctorRepository,IClinicServiceRepository clinicServiceRepository)
        {
            _doctorRepository = doctorRepository;
            _clinicServiceRepository = clinicServiceRepository;
        }

        public async Task<int> AddAsync(AddDoctorCommandModel doctorAdd, CancellationToken token)
        {

            var newDoctor = new Doctor()
            {
                Name = doctorAdd.Name,
                PhoneNumber = doctorAdd.PhoneNumber,
                Speciality = doctorAdd.Speciality,
                IsDeleted = false

            };
            foreach (var id in doctorAdd.ServiceIds)
            {
                var service = await _clinicServiceRepository.GetAndEnsureExistAsync(id);
                newDoctor.Services.Add(service);
            }
            await _doctorRepository.AddAsync(newDoctor);
            await _doctorRepository.SaveChangesAsync(token);
            return newDoctor.Id;

        }

        public async Task DeleteAsync(DeleteDoctorCommandModel doctorDelete, CancellationToken token)
        {
            var doctor = await _doctorRepository.GetAndEnsureExistAsync(doctorDelete.Id);
            doctor.IsDeleted = true;
            await _doctorRepository.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(UpdateDoctorCommandModel doctorUpdate, CancellationToken token)
        {
            var doctor = await _doctorRepository.GetAndEnsureExistAsync(doctorUpdate.Id);
            doctor.Name = doctorUpdate.Name;
            doctor.PhoneNumber = doctorUpdate.PhoneNumber;
            doctor.Speciality = doctorUpdate.Speciality;
            doctor.IsDeleted = false;
            var serviceList = new List<ClinicService>();
            foreach (var id in doctorUpdate.ServiceIds)
            {
                var service = await _clinicServiceRepository.GetAndEnsureExistAsync(id);
                serviceList.Add(service);
            }
            var isEqual = Enumerable.SequenceEqual(doctor.Services.OrderBy(z => z.Id), serviceList.OrderBy(z => z.Id));
            if (!isEqual)
            {
                doctor.Services.Clear();
                foreach (var service in serviceList)
                {
                    doctor.Services.Add(service);
                }
            }
            await _doctorRepository.SaveChangesAsync(token);
        }
    }
}

