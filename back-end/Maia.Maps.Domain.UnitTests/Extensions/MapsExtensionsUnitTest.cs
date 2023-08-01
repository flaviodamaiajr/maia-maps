using Maia.Maps.Domain.Extensions;

namespace Maia.Maps.Domain.UnitTests.Extensions
{
    public class MapsExtensionsUnitTest
    {
        [Fact(DisplayName = "Should convert Miles to Kilometers")]
        [Trait("Maps Extensions", "Miles to Kilometers")]
        public void Convert_Miles_To_Kilometers()
        {
            // Arrange
            double distanceInMiles = 10;

            // Act
            double result = distanceInMiles.ConvertMilesToKilometers();

            // Assert
            Assert.Equal(16.09344, result);
        }
        
        [Fact(DisplayName = "Should convert Kilometers to Miles")]
        [Trait("Maps Extensions", "Kilometers to Miles")]
        public void Convert_Kilometers_To_Miles()
        {
            // Arrange
            double distanceInKilometers = 16.09344;

            // Act
            double result = distanceInKilometers.ConvertKilometersToMiles();

            // Assert
            Assert.Equal(10, result);
        }
    }
}
