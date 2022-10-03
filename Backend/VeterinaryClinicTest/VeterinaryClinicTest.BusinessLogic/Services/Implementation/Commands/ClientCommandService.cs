using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands
{
    public class ClientCommandService:IClientCommandsService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProvidedServiceRepository _provideServiceRepository;
        private readonly IMapper _mapper;
        public ClientCommandService(IClientRepository clientRepository, IProvidedServiceRepository provideServiceRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _provideServiceRepository = provideServiceRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddClientCommandModel clientAdd, CancellationToken token)
        {
            var client = new Client()
            {
                Name = clientAdd.Name,
                PhoneNumber = clientAdd.PhoneNumber,
                Email = clientAdd.Email,
                Purchases = 0

            };
            await _clientRepository.AddAsync(client);
            await _clientRepository.SaveChangesAsync(token);
            return client.Id;
        }

       

        public async Task UpdateAsync(UpdateClientCommandModel clientUpdate, CancellationToken token)
        {
            var client = await _clientRepository.GetAndEnsureExistAsync(clientUpdate.Id);
            client.Name = clientUpdate.Name;
            client.PhoneNumber = clientUpdate.PhoneNumber;
            client.Email = clientUpdate.Email;
            await _clientRepository.SaveChangesAsync(token);

        }
    }
}

