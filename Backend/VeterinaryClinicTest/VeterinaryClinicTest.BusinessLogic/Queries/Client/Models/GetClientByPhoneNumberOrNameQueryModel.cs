using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Client.Models
{
    public class GetClientByPhoneNumberOrNameQueryModel : IRequest<IList<ClientListDto>>
    {
        public string SearchString { get; set; }
        public GetClientByPhoneNumberOrNameQueryModel(string searchString)
        {
            SearchString = searchString;
        }
    }
}

