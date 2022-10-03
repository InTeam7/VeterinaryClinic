using System;
using MediatR;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models
{
    public class DeleteClinicServiceCommandModel : IRequest
    {
        public int Id { get; set; }
        public DeleteClinicServiceCommandModel(int id)
        {
            Id = id;
        }
    }
}

