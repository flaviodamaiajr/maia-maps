namespace Maia.Maps.Domain.DTO.SearchHistory
{
    public record SearchDetailsViewModel
    {        
        public double Kilometers { get; }
        public double Miles { get; }

        public SearchDetailsViewModel(double kilometers, double miles)
        {
            Kilometers = kilometers;
            Miles = miles;
        }
    }
}
