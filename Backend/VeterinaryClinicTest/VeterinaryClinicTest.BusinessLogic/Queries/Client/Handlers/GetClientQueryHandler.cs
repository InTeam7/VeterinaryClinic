using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Client.Handlers
{
    public class GetClientQueryHandler : IRequestHandler<GetClientsQueryModel,IList<ClientListDto>>
    {
        private readonly IClientQueryService _clientQueryService;
        public GetClientQueryHandler(IClientQueryService clientQueryService)
        {
            _clientQueryService = clientQueryService;
        }

        public async Task<IList<ClientListDto>> Handle(GetClientsQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _clientQueryService.GetAsync();
            return result;
        }
    }
}

