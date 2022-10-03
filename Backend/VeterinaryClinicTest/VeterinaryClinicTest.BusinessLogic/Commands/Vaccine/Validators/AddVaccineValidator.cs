using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Validators
{
    public class AddVaccineValidator : AbstractValidator<AddVaccineCommandModel>
    {
        public AddVaccineValidator()
        {
            RuleFor(addVaccine =>
                    addVaccine.Title).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(addVaccine =>
                    addVaccine.Price).NotEmpty().NotNull();
            RuleFor(addVaccine =>
                    addVaccine.Count).NotEmpty().NotNull();
            RuleFor(addVaccine =>
                    addVaccine.Description).NotEmpty().NotNull().MaximumLength(2000);
            RuleFor(addVaccine =>
                    addVaccine.ExpirationDate).NotEmpty().NotNull();
            RuleFor(addVaccine =>
                    addVaccine.Date).NotEmpty().NotNull();
        }
    }
}

