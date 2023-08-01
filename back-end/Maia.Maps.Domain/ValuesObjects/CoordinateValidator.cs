using Maia.Maps.Domain.Extensions;
using FluentValidation;

namespace Maia.Maps.Domain.ValuesObjects
{
    public sealed class CoordinateValidator : AbstractValidator<Coordinate>
    {
        public CoordinateValidator()
        {
            RuleFor(a => a.Latitude).IsRequired();                
            RuleFor(a => a.Longitude).IsRequired();                
        }
    }
}
