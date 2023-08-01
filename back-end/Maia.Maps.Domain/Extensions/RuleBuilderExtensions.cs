using FluentValidation;

namespace Maia.Maps.Domain.Extensions
{
    public static class RuleBuilderExtensions
    {
        private const string PropertyName = "{PropertyName}";

        public static IRuleBuilderOptions<T, TProperty> IsRequired<T, TProperty>(this IRuleBuilder<T, TProperty> builder)
        {
            return builder.NotNull().NotEmpty().WithMessage($"Field {PropertyName} is required.");
        }
    }
}
