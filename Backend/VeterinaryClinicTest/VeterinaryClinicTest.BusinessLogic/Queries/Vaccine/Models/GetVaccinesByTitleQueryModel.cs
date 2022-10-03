using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models
{
    public class GetVaccinesByTitleQueryModel : IRequest<IList<VaccineListDto>>
    {
        public string Title { get; set; }

        public GetVaccinesByTitleQueryModel(string title)
        {
            Title = title;
        }
    }
}

