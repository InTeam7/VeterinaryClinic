using System;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands
{
    public class VaccineCommandsService : IVaccineCommandsService
    {
        private readonly IVaccineRepository _vaccineRepository;
        public VaccineCommandsService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public async Task<int> AddAsync(AddVaccineCommandModel vaccineAdd,CancellationToken token)
        {
            var newVaccine = new Vaccine()
            {
                Title = vaccineAdd.Title,
                Price = vaccineAdd.Price,
                Description = vaccineAdd.Description,
                Count = vaccineAdd.Count,
                ExpirationDate = vaccineAdd.ExpirationDate.Date,
                Date = vaccineAdd.Date.Date

            };
            var result = await _vaccineRepository.AddAsync(newVaccine);
            await _vaccineRepository.SaveChangesAsync(token);
            return result;
        }

        public async Task DeleteAsync(DeleteVaccineCommandModel vaccineDelete,CancellationToken token)
        {
            var vaccine = await _vaccineRepository.GetAndEnsureExistAsync(vaccineDelete.Id);
            vaccine.IsDeleted=true;
            await _vaccineRepository.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(UpdateVaccineCommandModel updateVaccine,CancellationToken token)
        {
            var vaccine = await _vaccineRepository.GetAndEnsureExistAsync(updateVaccine.Id);
            vaccine.Title = updateVaccine.Title;
            vaccine.Price = updateVaccine.Price;
            vaccine.Date = updateVaccine.Date.Date;
            vaccine.ExpirationDate = updateVaccine.ExpirationDate.Date;
            vaccine.Description = updateVaccine.Description;
            vaccine.Count = updateVaccine.Count;
            vaccine.IsDeleted = false;
            await _vaccineRepository.SaveChangesAsync(token);
        }
    }
}

