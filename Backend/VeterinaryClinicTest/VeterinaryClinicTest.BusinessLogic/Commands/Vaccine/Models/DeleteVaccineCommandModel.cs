using System;
using MediatR;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models
{
    public class DeleteVaccineCommandModel : IRequest
    {
        public int Id { get; protected set; }

        public DeleteVaccineCommandModel(int id)
        {
            Id = id;
        }
    }
}

