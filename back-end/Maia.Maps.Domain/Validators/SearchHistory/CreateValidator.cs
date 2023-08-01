using Maia.Maps.Domain.DTO.SearchHistory;
using Maia.Maps.Domain.ValuesObjects;
using FluentValidation;

namespace Maia.Maps.Domain.Validators.SearchHistory
{
    public class CreateValidator : AbstractValidator<CreateSearchHistoryCommand>
    {
        public CreateValidator()
        {
            RuleFor(c => c.Postcode!).NotNull().SetValidator(new PostCodeValidator());
            RuleFor(a => a.CoordinatesFrom!).NotNull().SetValidator(new CoordinateValidator());
            RuleFor(a => a.CoordinatesTo!).NotNull().SetValidator(new CoordinateValidator());
        }
    }
}
