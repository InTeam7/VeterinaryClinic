using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Validators
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctorCommandModel>
    {
        public UpdateDoctorValidator()
        {
            RuleFor(upDoc =>
                    upDoc.Id).NotEmpty().NotNull();
            RuleFor(upDoc =>
                    upDoc.Name).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(upDoc =>
                    upDoc.PhoneNumber).NotEmpty().NotNull().MaximumLength(20).MinimumLength(19);
            RuleFor(upDoc =>
                    upDoc.Speciality).NotEmpty().NotNull().MaximumLength(100);
            RuleForEach(upDoc =>
                    upDoc.ServiceIds).NotEmpty().NotNull();
        }
    }
}

