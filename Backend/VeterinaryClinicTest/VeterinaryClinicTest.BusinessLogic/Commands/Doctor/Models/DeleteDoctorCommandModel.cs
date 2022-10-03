using System;
using MediatR;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models
{
    public class DeleteDoctorCommandModel: IRequest
    {
        public int Id { get; set; }
        public DeleteDoctorCommandModel(int id)
        {
            Id = id;
        }
    }
}

