using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Helpers;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;
using VeterinaryClinicTest.Core.Exceptions;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries
{
    public class ClientQueryService : IClientQueryService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;
        private readonly ISearchClientService _searchClientService;
        public ClientQueryService(IClientRepository clientRepository,
            IMapper mapper,
            IMemoryCache memoryCache,
            ISearchClientService searchClientService)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _cache = memoryCache;
            _searchClientService = searchClientService;
        }

        public async Task<IList<ClientListDto>> GetAsync()
        {
            var clients = await _clientRepository.GetListAsync();
            if (clients.Count > 0)
            {
                _cache.Set("clientList", clients, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                });
                
            }

            return _mapper.Map<IList<ClientListDto>>(clients);
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var client = await _clientRepository.GetAndEnsureExistAsync(id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<IList<ClientListDto>> GetByPhoneNumberAndName(string searchString)
        {
            var res = _cache.Get("clientList");
            if (!_cache.TryGetValue("clientList", out IList<Client> clientList))
            {
                clientList = await _clientRepository.GetListAsync();
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                };
                _cache.Set("clientList", clientList, cacheExpiryOptions);
            }
            var findClient =  await _searchClientService.Search(clientList, searchString);
            return findClient;
        }

    }
}

