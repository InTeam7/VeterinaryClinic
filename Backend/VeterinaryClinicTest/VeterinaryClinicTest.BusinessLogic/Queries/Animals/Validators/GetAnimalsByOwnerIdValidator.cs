using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Animals.Validators
{
    public class GetAnimalsByOwnerIdValidator : AbstractValidator<GetAnimalsByOwnerIdQueryModel>
    {
        public GetAnimalsByOwnerIdValidator()
        {
            RuleFor(getAnimalById =>
                getAnimalById.Id).NotEmpty().NotNull();
        }
    }
}

