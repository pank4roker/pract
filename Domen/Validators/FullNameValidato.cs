using Domen.Primitives;
using Domen.ValueObject;
using FluentValidation;
namespace Domen.Validators;

public class FullNameValidato : AbstractValidator<FullName>
{
    public FullNameValidator()
    {
        RuleFor(expression: x => x.FirstName)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .Matches(expression: @"^[a-zA-Zа-яА-Я]+$")
            .WithMessage(x => ValidationMessages.IsRight);
        RuleFor(expression: x => x.LastName)
            .NotNull().WithMessage(x => ValidationMessages.IsNull)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .Matches(expression: @"^[a-zA-Zа-яА-Я]+$")
            .WithMessage(x => ValidationMessages.IsRight);
        RuleFor(expression: x => x.MiddleName)
            .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
            .Matches(expression: @"^[a-zA-Zа-яА-Я]+$")
            .WithMessage(x => ValidationMessages.IsRight);
    }
}