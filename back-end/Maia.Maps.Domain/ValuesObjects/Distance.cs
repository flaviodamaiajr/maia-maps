namespace Maia.Maps.Domain.ValuesObjects
{
    public class Distance : ValueObject
    {
        public Distance(double kilometers, double miles)
        {
            Kilometers = kilometers;
            Miles = miles;
        }
    
        public double Kilometers { get; private set; }
        public double Miles { get; private set; }
    }
}
