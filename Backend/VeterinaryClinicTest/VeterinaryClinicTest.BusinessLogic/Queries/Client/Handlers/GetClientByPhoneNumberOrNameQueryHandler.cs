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
    public class GetClientByPhoneNumberOrNameQueryHandler : IRequestHandler<GetClientByPhoneNumberOrNameQueryModel,IList<ClientListDto>>
    {
        private readonly IClientQueryService _clientQueryService;
        public GetClientByPhoneNumberOrNameQueryHandler(IClientQueryService clientQueryService)
        {
            _clientQueryService = clientQueryService;
        }

        public async Task<IList<ClientListDto>> Handle(GetClientByPhoneNumberOrNameQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _clientQueryService.GetByPhoneNumberAndName(request.SearchString);
            return result;
        }
    }
}

