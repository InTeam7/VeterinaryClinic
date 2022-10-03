using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models
{
    public class GetAnimalsQueryModel : IRequest<IList<AnimalListDto>>
    {
        
    }
}

