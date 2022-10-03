using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models
{
    public class GetClinicServicesQueryModel : IRequest<IList<ClinicServiceListDto>>
    {
        public GetClinicServicesQueryModel()
        {
        }
    }
}

