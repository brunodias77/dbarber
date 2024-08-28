
using System.ComponentModel;
using DB.Application.Communications.Requests.Users;
using DB.Exceptions;
using FluentValidation;

namespace DB.Application.UseCases.Users.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequestJson>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100).WithMessage(ResourceMessagesException.FIRST_NAME_EMPTY);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100).WithMessage(ResourceMessagesException.LAST_NAME_EMPTY);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage(ResourceMessagesException.PASSWORD_GREATER_THAN_OR_EQUAL_TO_SIX);
        }
    }
}