using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Validators
{
    public class GetClinicServiceByIdValidator : AbstractValidator<GetClinicServiceByIdQueryModel>
    {
        public GetClinicServiceByIdValidator()
        {
            RuleFor(getServiceById =>
                getServiceById).NotNull().NotEmpty();
        }
    }
}

