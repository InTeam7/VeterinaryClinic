using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Validators
{
    public class GetVaccineByTitleValidator : AbstractValidator<GetVaccinesByTitleQueryModel>
    {
        public GetVaccineByTitleValidator()
        {
            RuleFor(getVacByTitle =>
                    getVacByTitle.Title).MaximumLength(200);
        }
    }
}

