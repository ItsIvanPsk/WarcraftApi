using FluentValidation;

namespace WarcraftApi.DistributedServices.WebApi.Validations;

public class StringValidator : AbstractValidator<string>
{
    public StringValidator()
    {
        RuleFor(value => value)
            .NotEmpty().WithMessage(Properties.Resources.ResourceManager.GetString("ValueCannotBeEmpty"));
    }
}