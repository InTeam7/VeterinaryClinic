using System;
using FluentValidation;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Client.Validators
{
    public class UpdateClientValidator : AbstractValidator<UpdateClientCommandModel>
    {
        public UpdateClientValidator()
        {
            RuleFor(upClient =>
                    upClient.Id).NotEmpty().NotNull();

            RuleFor(upClient =>
                    upClient.Name).NotEmpty().NotNull().MaximumLength(20);
            RuleFor(upClient =>
                    upClient.PhoneNumber).NotEmpty().NotNull().MaximumLength(20).MinimumLength(19); ;
            RuleFor(upClient =>
                    upClient.Email).NotEmpty().NotNull().EmailAddress();
            
        }
    }
}

