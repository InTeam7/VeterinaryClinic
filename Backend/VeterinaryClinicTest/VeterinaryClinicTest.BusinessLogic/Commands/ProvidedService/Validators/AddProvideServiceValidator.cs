using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Validators
{
    public class AddProvideServiceValidator: AbstractValidator<AddProvidedServiceCommandModel>
    {
        public AddProvideServiceValidator()
        {
            RuleFor(addService =>
                    addService.AnimalId).NotNull().NotEmpty();
            RuleFor(addService =>
                    addService.ServiceId).NotNull().NotEmpty();
            RuleFor(addService =>
                    addService.DoctorId).NotNull().NotEmpty();
        }
    }
}

