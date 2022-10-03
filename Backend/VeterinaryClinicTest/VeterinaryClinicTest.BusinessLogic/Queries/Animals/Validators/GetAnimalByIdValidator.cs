using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Validators
{
    public class GetAnimalByIdValidator : AbstractValidator<GetAnimalByIdQueryModel>
    {
        public GetAnimalByIdValidator()
        {
            RuleFor(getAnimalById =>
                getAnimalById.Id).NotEmpty().NotNull();
        }
    }
}

