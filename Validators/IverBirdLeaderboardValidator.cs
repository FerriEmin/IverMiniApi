using FluentValidation;
using IverMiniApi.Models;

namespace IverMiniApi.Validators
{
    public class IverBirdLeaderboardValidator : AbstractValidator<IverBirdLeaderboard>
    {
        public IverBirdLeaderboardValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Score).NotEmpty().GreaterThan(0);

        }
    }
}
