using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Queries;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Client.Handlers
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQueryModel,ClientDto>
    {
        private readonly IClientQueryService _clientQueryService;
        public GetClientByIdQueryHandler(IClientQueryService clientQueryService)
        {
            _clientQueryService = clientQueryService;
        }

        public async Task<ClientDto> Handle(GetClientByIdQueryModel request, CancellationToken cancellationToken)
        {
            var result = await _clientQueryService.GetByIdAsync(request.Id);
            return result;
        }
    }
}

