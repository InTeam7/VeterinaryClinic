using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Client.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Client.Validators
{
    public class GetClientByIdValidator : AbstractValidator<GetClientByIdQueryModel>
    {
        public GetClientByIdValidator()
        {
            RuleFor(getClientById =>
                getClientById).NotNull().NotEmpty();
        }
    }
}

