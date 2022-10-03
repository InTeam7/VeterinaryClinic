using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Client.Models
{
    public class UpdateClientCommandModel : IRequest
    {
        public int Id { get;protected set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public UpdateClientCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }

        

    }
}

