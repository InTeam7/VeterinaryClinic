using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Validators
{
    public class DeleteClinicServiceValidator : AbstractValidator<DeleteClinicServiceCommandModel>
    {
        public DeleteClinicServiceValidator()
        {
            RuleFor(deleteService =>
                    deleteService.Id).NotNull().NotEmpty();
        }
    }
}

