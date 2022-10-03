using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Animal.Validators
{
    public class AddAnimalValidator : AbstractValidator<AddAnimalCommandModel>
    {
        public AddAnimalValidator()
        {
            RuleFor(createAnimal =>
                createAnimal.Name).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(createAnimal =>
                createAnimal.Age).NotNull().NotEmpty().InclusiveBetween(0,30);
            RuleFor(createAnimal =>
                createAnimal.FileName).MaximumLength(50);
            RuleFor(createAnimal =>
                createAnimal.OwnerId).NotNull().NotEmpty();
            RuleFor(createAnimal =>
                createAnimal.Gender).NotNull().IsInEnum();
            RuleFor(createAnimal =>
                createAnimal.Specie).NotNull().IsInEnum();

        }
    }
}

