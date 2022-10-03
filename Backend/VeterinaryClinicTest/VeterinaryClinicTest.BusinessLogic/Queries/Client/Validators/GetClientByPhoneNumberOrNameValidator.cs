using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Client.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Client.Validators
{
    public class GetClientByPhoneNumberValidator : AbstractValidator<GetClientByPhoneNumberOrNameQueryModel>
    {
        public GetClientByPhoneNumberValidator()
        {
            RuleFor(getClientPhone =>
                getClientPhone.SearchString)
                .MaximumLength(50);
                
        }
    }
}

