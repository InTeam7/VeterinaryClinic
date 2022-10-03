using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Client.Validators
{
    public class AddClientValidator : AbstractValidator<AddClientCommandModel>
    {
        public AddClientValidator()
        { 
            RuleFor(addClient=>
                    addClient.Name).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(addClient =>
                    addClient.PhoneNumber).NotEmpty().NotNull().MaximumLength(20).MinimumLength(19); ;
            

        }
    }
}

