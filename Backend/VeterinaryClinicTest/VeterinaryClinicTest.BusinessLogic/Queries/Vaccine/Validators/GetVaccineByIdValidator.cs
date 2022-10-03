using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Validators
{
    public class GetVaccineByIdValidator : AbstractValidator<GetVaccineByIdQueryModel>
    {
        public GetVaccineByIdValidator()
        {
            RuleFor(getVacById =>
                    getVacById).NotEmpty().NotNull();
        }
    }
}

