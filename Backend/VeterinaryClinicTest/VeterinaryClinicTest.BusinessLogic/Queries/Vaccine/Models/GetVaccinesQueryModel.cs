using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models
{
    public class GetVaccinesQueryModel : IRequest<IList<VaccineListDto>>
    {
       
    }
}

