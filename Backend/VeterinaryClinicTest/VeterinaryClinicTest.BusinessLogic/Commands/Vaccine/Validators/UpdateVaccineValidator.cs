using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Validators
{
    public class UpdateVaccineValidator : AbstractValidator<UpdateVaccineCommandModel>
    {
        public UpdateVaccineValidator()
        {
            RuleFor(upVac =>
                    upVac.Id).NotEmpty().NotNull();
            RuleFor(upVac =>
                    upVac.Price).NotEmpty().NotNull();
            RuleFor(upVac =>
                    upVac.Title).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(upVac =>
                    upVac.Count).NotEmpty().NotNull();
            RuleFor(upVac =>
                    upVac.Description).NotEmpty().NotNull().MaximumLength(2000);
            RuleFor(upVac =>
                    upVac.ExpirationDate).NotEmpty().NotNull();
            RuleFor(upVac =>
                   upVac.Date).NotEmpty().NotNull();
        }

    }
}

