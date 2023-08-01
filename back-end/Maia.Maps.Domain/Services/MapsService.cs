using Maia.Maps.Domain.Extensions;
using Maia.Maps.Domain.Interfaces.Services;
using Maia.Maps.Domain.ValuesObjects;

namespace Maia.Maps.Domain.Services
{
    internal sealed class MapsService : IMapsService
    {
        public (double kilometers, double miles) CalculateDistanceByCoords(Coordinate from, Coordinate to)
        {
            if ((from.Latitude == to.Latitude) && (from.Longitude == to.Longitude))
            {
                return (0, 0);
            }

            double theta = from.Longitude - to.Longitude;
            double dist = Math.Sin(ConverterDegToRad(from.Latitude)) * Math.Sin(ConverterDegToRad(to.Latitude)) + Math.Cos(ConverterDegToRad(from.Latitude)) * Math.Cos(ConverterDegToRad(to.Latitude)) * Math.Cos(ConverterDegToRad(theta));
            dist = Math.Acos(dist);
            dist = ConverterRadToDeg(dist);
            dist = dist * 60 * 1.1515;
            
            return (dist.ConvertMilesToKilometers(), dist);
        }

        private static double ConverterDegToRad(double deg)
        {
            return deg * Math.PI / 180.0;
        }

        private static double ConverterRadToDeg(double rad)
        {
            return rad / Math.PI * 180.0;
        }

    }
}
