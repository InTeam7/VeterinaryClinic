using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Validators
{
    public class UpdateClinicServiceValidator : AbstractValidator<UpdateClinicServiceCommandModel>
    {
        public UpdateClinicServiceValidator()
        {
            RuleFor(upService =>
                    upService.Id).NotEmpty().NotNull();

            RuleFor(upService =>
                    upService.Description).NotEmpty().NotNull().MaximumLength(2000);
            RuleFor(upService =>
                    upService.Title).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(upService =>
                    upService.Price).NotEmpty().NotNull();


        }
    }
}

