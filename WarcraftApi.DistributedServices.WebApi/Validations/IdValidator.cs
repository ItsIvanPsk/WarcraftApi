using FluentValidation;

namespace WarcraftApi.DistributedServices.WebApi.Validations;

public class IdValidator : AbstractValidator<long>
{
    public IdValidator()
    {
        RuleFor(value => value)
            .NotEmpty().WithMessage(Properties.Resources.ResourceManager.GetString("ValueCannotBeEmpty"))
            .GreaterThan(0).WithMessage(Properties.Resources.ResourceManager.GetString("ValueMustBeGreatherThan0"));
    }
}