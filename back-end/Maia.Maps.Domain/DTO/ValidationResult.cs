using FluentValidation;
using FluentValidation.Results;

namespace Maia.Maps.Domain.DTO
{
    public class ValidationResult : Result
    {
        public ValidationResult(ValidationException validationException) 
            : this(validationException.Errors)
        {
        }

        public ValidationResult(IEnumerable<ValidationFailure> erros)
        {
            Erros = erros.GroupBy(v => v.PropertyName)
                .ToDictionary(v => v.Key, v => v.Count() > 1 ? (object)v.Select(e => e.ErrorMessage).ToArray() : v.First().ErrorMessage);
        }

        public Dictionary<string, object> Erros { get; set; }
    }
}
