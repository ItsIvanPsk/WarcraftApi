using FluentValidation;
using WarcraftApi.DistributedServices.Models;

namespace WarcraftApi.DistributedServices.WebApi.Validations;

public class CharacterResponseListValidator : AbstractValidator<List<CharacterDto>>
{
    public CharacterResponseListValidator()
    {
        RuleForEach(list => list)
            .SetValidator(new CharacterResponseDtoValidator());
    }
}