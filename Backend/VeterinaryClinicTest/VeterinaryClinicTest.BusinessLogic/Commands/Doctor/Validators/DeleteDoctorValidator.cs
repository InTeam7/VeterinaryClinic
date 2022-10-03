using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Validators
{
    public class DeleteDoctorValidator : AbstractValidator<DeleteDoctorCommandModel>
    {
        public DeleteDoctorValidator()
        {
            RuleFor(deleteDoc =>
                    deleteDoc.Id).NotEmpty().NotNull();
        }
    }
}

