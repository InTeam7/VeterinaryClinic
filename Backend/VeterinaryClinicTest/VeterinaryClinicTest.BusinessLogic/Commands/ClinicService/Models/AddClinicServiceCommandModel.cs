using System;
using System.Collections.Generic;
using MediatR;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models
{
    public class AddClinicServiceCommandModel:IRequest<int>
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public List<int> DoctorIds { get; set; }
    }
}

