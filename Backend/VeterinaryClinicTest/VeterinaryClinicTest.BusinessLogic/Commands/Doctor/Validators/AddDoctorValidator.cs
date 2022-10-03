using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Validators
{
    public class AddDoctorValidator : AbstractValidator<AddDoctorCommandModel>
    {
        public AddDoctorValidator()
        {
            RuleFor(createDoc =>
                    createDoc.Name).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(createDoc =>
                    createDoc.PhoneNumber).NotNull().NotEmpty().MaximumLength(20).MinimumLength(19);
            RuleFor(createDoc =>
                    createDoc.Speciality).NotNull().NotEmpty().MaximumLength(100);
            RuleForEach(createDoc =>
                    createDoc.ServiceIds).NotNull().NotEmpty();

        }
    }
}

