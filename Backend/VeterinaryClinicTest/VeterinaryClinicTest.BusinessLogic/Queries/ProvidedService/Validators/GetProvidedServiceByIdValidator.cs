using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Handlers;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Validators
{
    public class GetProvidedServiceByIdValidator : AbstractValidator<GetProvidedServiceByIdQueryHandler>
    {
        public GetProvidedServiceByIdValidator()
        {
            RuleFor(getProvServiceById =>
                    getProvServiceById).NotEmpty().NotNull();
        }
    }
}

