using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Validators
{
    public class GetDoctorByNameValidator : AbstractValidator<GetDoctorsByNameQueryModel>
    {
        public GetDoctorByNameValidator()
        {
            RuleFor(getDocByName =>
                 getDocByName.Name).MaximumLength(200);
        }
    }
}

