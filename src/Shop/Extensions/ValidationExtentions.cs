using FluentValidation;

namespace Shop.Extensions
{
    public static class ValidationExtentions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder,
            int minimumLength = 6)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(minimumLength).WithMessage($"Password should have at least {minimumLength} characters")
                .Matches("[A-Z]").WithMessage("Password should contain at least one upper case letter")
                .Matches("[0-9]").WithMessage("Password should contain at least 1 number");
            return options;
        }


    }
}