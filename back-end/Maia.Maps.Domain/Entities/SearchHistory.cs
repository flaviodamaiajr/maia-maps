using Maia.Maps.Domain.ValuesObjects;

namespace Maia.Maps.Domain.Entities
{
    public class SearchHistory : EntityBase
    {
        public PostCode PostCode { get; set; }
        public Distance? Distance { get; }
        public Coordinate CoordinatesFrom { get; }
        public Coordinate CoordinatesTo { get; }

        public SearchHistory()
        {
            // It´s required for EF Core
        }

        public SearchHistory(PostCode postCode, Coordinate coordinatesFrom, Coordinate coordinatesTo)
        {
            PostCode = postCode;
            CoordinatesFrom = coordinatesFrom;
            CoordinatesTo = coordinatesTo;
        }

        public SearchHistory(PostCode postCode, Distance distance, Coordinate coordinatesFrom, Coordinate coordinatesTo)
        {
            PostCode = postCode;
            Distance = distance;
            CoordinatesFrom = coordinatesFrom;
            CoordinatesTo = coordinatesTo;
        }
    }
}
