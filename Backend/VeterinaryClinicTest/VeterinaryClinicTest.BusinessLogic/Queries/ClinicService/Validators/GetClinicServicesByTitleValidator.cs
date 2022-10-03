using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Validators
{
    public class GetClinicServicesByTitleValidator : AbstractValidator<GetClinicServicesByTitleQueryModel>
    {
        public GetClinicServicesByTitleValidator()
        {
            RuleFor(getServiceByTitle =>
                getServiceByTitle.Title)
                .MaximumLength(200);
        }
    }
}

