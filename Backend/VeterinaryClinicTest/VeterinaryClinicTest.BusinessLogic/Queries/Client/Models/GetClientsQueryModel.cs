using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Client.Models
{
    public class GetClientsQueryModel : IRequest<IList<ClientListDto>>
    {
        public GetClientsQueryModel()
        {
        }
    }
}

