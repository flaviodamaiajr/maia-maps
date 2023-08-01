namespace Maia.Maps.Domain.ValuesObjects
{
    public class Coordinate : ValueObject
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
