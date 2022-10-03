using System;
using MediatR;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Models
{
    public class AddProvidedServiceCommandModel : IRequest<int>
    {
        public int AnimalId { get; set; }

        public int ServiceId { get; set; }

        public int DoctorId { get; set; }

        public string Diagnosis { get; set; }

        public string Ananmnesis { get; set; }

        public int? VaccineId { get; set; }

    }
}

