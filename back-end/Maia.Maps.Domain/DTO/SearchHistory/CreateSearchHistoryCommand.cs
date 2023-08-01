using Maia.Maps.Domain.ValuesObjects;
using MediatR;

namespace Maia.Maps.Domain.DTO.SearchHistory
{
    public record CreateSearchHistoryCommand : IRequest<Result<SearchDetailsViewModel>>
    {
        public PostCode? Postcode { get; set; }
        public Coordinate? CoordinatesFrom { get; set; }
        public Coordinate? CoordinatesTo { get; set; }        

    }
}
