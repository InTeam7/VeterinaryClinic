using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Validators
{
    public class GetAnimalByNameValidator : AbstractValidator<GetAnimalsByNameQueryModel>
    {
        public GetAnimalByNameValidator()
        {
            RuleFor(getAnimalByName =>
                getAnimalByName.Name).MaximumLength(30);
        }
    }
}

