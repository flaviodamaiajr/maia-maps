using System.Net.Http.Json;
using System.Net;
using Maia.Maps.Domain.DTO;
using Maia.Maps.Domain.DTO.SearchHistory;
using Maia.Maps.Domain.ValuesObjects;

namespace Maia.Maps.Api.Tests
{
    public class SearchHistoryControllerUnitTest
    {
        [Fact(DisplayName = "Should return latest searches")]
        [Trait("GET", "Latest searches")]
        public async Task GET_Should_Return_Latest_Searches()
        {
            // Arrange
            await using var application = new ApiApplication();

            await MapsMockData.CreateSearchHistoryMockData(application, create: true);

            // Act
            var client = application.CreateClient();

            var result = await client.GetAsync("/v1/SearchHistory");
            var searches = await client.GetFromJsonAsync<PagedList<LatestSearchHistoriesViewModel>>("/v1/SearchHistory");

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(searches);
            Assert.Equal(3, searches!.Items.Count);
        }

        [Fact(DisplayName = "Should return a search history by id")]
        [Trait("GET", "search history by id")]
        public async Task GET_Should_Return_SearchHistoryById()
        {
            // Arrange
            await using var application = new ApiApplication();

            await MapsMockData.CreateSearchHistoryMockData(application, create: true);

            // act
            var client = application.CreateClient();

            var result = await client.GetAsync("/v1/SearchHistory/1");
            var search = await client.GetFromJsonAsync<DistanceViewModel>("/v1/SearchHistory/1");

            var expected = new DistanceViewModel()
            {
                PostcodeFrom = "N76RS",
                PostcodeTo = "SW46TA"
            };

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(search);
            Assert.Equal(expected, search);
        }

        [Fact(DisplayName = "Should return http status no content")]
        [Trait("GET", "return http status no content")]
        public async Task GET_Should_Return_SearchHistory_No_Content()
        {
            // Arrange
            await using var application = new ApiApplication();

            await MapsMockData.CreateSearchHistoryMockData(application, create: true);

            // Act
            var client = application.CreateClient();

            var result = await client.GetAsync("/v1/SearchHistory/10");

            // Assert
            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact(DisplayName = "Should create a search history")]
        [Trait("POST", "create a search history")]
        public async Task POST_Should_Create_SearchHistory()
        {
            // Arrange
            await using var application = new ApiApplication();

            await MapsMockData.CreateSearchHistoryMockData(application, create: false);

            var searchHistory = new CreateSearchHistoryCommand()
            {
                Postcode = new PostCode("N76RS", "SW46TA"),
                CoordinatesFrom = new Coordinate(1.560414, -0.116805),
                CoordinatesTo = new Coordinate(51.472716, -0.12278)
            };

            // Act
            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/v1/SearchHistory", searchHistory);

            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact(DisplayName = "Should failure to create a search history")]
        [Trait("POST", "failure to create a search history")]
        public async Task POST_Should_Fails_Create_SearchHistory()
        {
            // Arrange
            await using var application = new ApiApplication();

            await MapsMockData.CreateSearchHistoryMockData(application, create: false);

            var searchHistory = new CreateSearchHistoryCommand();

            // Act
            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/v1/SearchHistory", searchHistory);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}