using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Validators
{
    public class GetProvidedServiceByDoctorNameValidator : AbstractValidator<GetProvidedServicesByDoctorNameQueryModel>
    {
        public GetProvidedServiceByDoctorNameValidator()
        {
            RuleFor(getProvService =>
                getProvService.Name).MaximumLength(200);
        }
    }
}

