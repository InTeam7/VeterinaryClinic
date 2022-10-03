using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Validators
{
    public class AddClinicServiceValidator : AbstractValidator<AddClinicServiceCommandModel>
    {
        public AddClinicServiceValidator()
        {
            RuleFor(createService =>
                    createService.Description).NotEmpty().NotNull().MaximumLength(2000);
            RuleFor(createService =>
                    createService.Title).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(createService =>
                    createService.Title).NotEmpty().NotNull();

        }
    }
}

