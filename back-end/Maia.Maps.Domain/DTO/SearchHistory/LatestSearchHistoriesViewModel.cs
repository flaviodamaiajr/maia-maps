using Maia.Maps.Domain.ValuesObjects;

namespace Maia.Maps.Domain.DTO.SearchHistory
{
    public record LatestSearchHistoriesViewModel
    {
        public long Id { get; set; }
        public required PostCode PostCode { get; set; }
        public required Coordinate CoordinateFrom { get; set; }
        public required Coordinate CoordinateTo { get; set; }
        public required Distance Distance { get; set; }
        public DateTime CreatedAt {get; set; }
    }
}
