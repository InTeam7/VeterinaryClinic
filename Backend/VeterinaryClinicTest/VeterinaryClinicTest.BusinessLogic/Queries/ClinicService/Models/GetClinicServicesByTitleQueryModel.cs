using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models
{
    public class GetClinicServicesByTitleQueryModel : IRequest<IList<ClinicServiceListDto>>
    {
        public string Title { get; set; }
        public GetClinicServicesByTitleQueryModel(string title)
        {
            Title = title;
        }
    }
}

