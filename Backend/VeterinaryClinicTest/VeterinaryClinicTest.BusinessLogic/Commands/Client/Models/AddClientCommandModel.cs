using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Commands;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Enums;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Client.Models
{
    public class AddClientCommandModel:IRequest<int>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        
    }
}

