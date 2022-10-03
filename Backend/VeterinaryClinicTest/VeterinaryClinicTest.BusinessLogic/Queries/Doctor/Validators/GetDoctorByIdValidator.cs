using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Validators
{
    public class GetDoctorByIdValidator : AbstractValidator<GetDoctorByIdQueryModel>
    {
        public GetDoctorByIdValidator()
        {
            RuleFor(getDocById =>
                getDocById).NotNull().NotEmpty();
        }
    }
}

