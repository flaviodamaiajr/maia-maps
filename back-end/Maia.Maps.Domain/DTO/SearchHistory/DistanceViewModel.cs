using Maia.Maps.Domain.ValuesObjects;

namespace Maia.Maps.Domain.DTO.SearchHistory
{
    public record DistanceViewModel
    {
        public Distance Distance { get; set; }
        public string PostcodeFrom { get; set; }
        public string PostcodeTo { get; set; }

    }
}
