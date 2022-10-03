using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Validators
{
    public class DeleteVaccineValidator : AbstractValidator<DeleteVaccineCommandModel>
    {
        public DeleteVaccineValidator()
        {
            RuleFor(deleteVac =>
                    deleteVac.Id).NotNull().NotEmpty();
        }
    }
}

