namespace Maia.Maps.Domain.Extensions
{
    public static class MapsExtensions
    {
        public static double ConvertMilesToKilometers(this double miles)
        {
            return miles * 1.609344;
        }

        public static double ConvertKilometersToMiles(this double kilometers)
        {
            return kilometers / 1.609344;
        }
    }
}
