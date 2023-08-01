using FluentValidation;
using Maia.Maps.Domain.Extensions;

namespace Maia.Maps.Domain.ValuesObjects
{
    public sealed class PostCodeValidator : AbstractValidator<PostCode>
    {
        public PostCodeValidator()
        {
            RuleFor(c => c.From).IsRequired().MaximumLength(15);
            RuleFor(c => c.To).IsRequired().MaximumLength(15);
        }
    }
}
