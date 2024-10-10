using FluentValidation;
using WarcraftApi.DistributedServices.Models;

namespace WarcraftApi.DistributedServices.WebApi.Validations;

public class CharacterResponseDtoValidator : AbstractValidator<CharacterDto>
{
    public CharacterResponseDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Damage).GreaterThan(0);
        RuleFor(x => x.Life).GreaterThan(0);
        RuleFor(x => x.Speed).GreaterThanOrEqualTo(0);
    }
}