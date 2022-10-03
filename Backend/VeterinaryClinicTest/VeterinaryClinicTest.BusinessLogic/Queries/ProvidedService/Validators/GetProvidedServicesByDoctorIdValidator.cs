using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Validators
{
    public class GetProvidedServicesByDoctorIdValidator : AbstractValidator<GetProvidedServicesByDoctorNameQueryModel>
    {
        public GetProvidedServicesByDoctorIdValidator()
        {
            RuleFor(getProvServiceByDocId =>
                    getProvServiceByDocId).NotEmpty().NotNull();
        }
    }
}

