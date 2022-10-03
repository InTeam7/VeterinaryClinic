using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Animal.Validators
{
    public class UpadateAnimalValidator : AbstractValidator<UpdateAnimalCommandModel>
    {
        public UpadateAnimalValidator()
        {
            RuleFor(upAnimal =>
                upAnimal.Id).NotEmpty().NotNull();

            RuleFor(upAnimal =>
                upAnimal.Age).NotEmpty().NotNull().ExclusiveBetween(0,30);
            RuleFor(upAnimal =>
               upAnimal.Name).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(upAnimal =>
                upAnimal.FileName).MaximumLength(50).NotEmpty();
            RuleFor(upAnimal =>
               upAnimal.Gender).NotNull().IsInEnum();
            RuleFor(upAnimal =>
               upAnimal.Specie).NotNull().IsInEnum();
           
        } 
    }
}

