using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models
{
    public class UpdateClinicServiceCommandModel:IRequest
    {
        public int Id { get;protected set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<int> DoctorIds { get; set; }

        public UpdateClinicServiceCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}

