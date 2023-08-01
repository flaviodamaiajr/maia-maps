using Maia.Maps.Domain.ValuesObjects;

namespace Maia.Maps.Domain.Interfaces.Services
{
    public interface IMapsService
    {
        (double kilometers, double miles) CalculateDistanceByCoords(Coordinate from, Coordinate to);
    }
}
