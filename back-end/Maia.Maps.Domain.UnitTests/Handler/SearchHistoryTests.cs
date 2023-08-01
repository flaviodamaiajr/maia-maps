using Maia.Maps.Domain.DTO;
using Maia.Maps.Domain.DTO.SearchHistory;
using Maia.Maps.Domain.Entities;
using Maia.Maps.Domain.Handlers;
using Maia.Maps.Domain.Interfaces;
using Maia.Maps.Domain.Interfaces.Repositories;
using Maia.Maps.Domain.Interfaces.Services;
using Maia.Maps.Domain.ValuesObjects;
using Moq;

namespace Maia.Maps.Domain.UnitTests.Handler
{
    public class SearchHistoryTests
    {
        private readonly Mock<ISearchHistoryRepository> _searchHistoryRepositoryMock;
        private readonly Mock<IMapsService> _mapsServiceMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public SearchHistoryTests()
        {
            _searchHistoryRepositoryMock = new();
            _unitOfWorkMock = new();
            _mapsServiceMock = new();
        }

        [Fact(DisplayName = "Should create a search history")]
        [Trait("Add", "Create")]
        public async Task Handle_Should_Create_Search_History()
        {
            // Arrange
            var command = new CreateSearchHistoryCommand()
            {
                Postcode = new PostCode("N76RS", "SW46TA"),
                CoordinatesFrom = new Coordinate(1.560414, -0.116805),
                CoordinatesTo = new Coordinate(51.472716, -0.12278)
            };

            var handler = new SearchHistoryHandler(_searchHistoryRepositoryMock.Object, _unitOfWorkMock.Object, _mapsServiceMock.Object);

            var searchHistory = new SearchHistory(command.Postcode, command.CoordinatesFrom, command.CoordinatesTo);

            _searchHistoryRepositoryMock.Setup(x => x.Add(It.IsAny<SearchHistory>())).Verifiable();
            _mapsServiceMock.Setup(x => x.CalculateDistanceByCoords(command.CoordinatesFrom, command.CoordinatesTo)).Returns((kilometers: 5532.1, miles: 3437.5));
            _unitOfWorkMock.Setup(x => x.CommitAsync(default)).Returns(Task.FromResult(1));

            // Act
            var result = await handler.Handle(command, default);

            // Assert           
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Should fetch latest searches")]
        [Trait("List", "Latest searches")]
        public async Task Handle_Should_Fetch_Latest_Searches()
        {
            // Arrange
            var expected = new PagedList<LatestSearchHistoriesViewModel>()
            {
                Items = new List<LatestSearchHistoriesViewModel>()
                {
                    new LatestSearchHistoriesViewModel(){
                        PostCode = new PostCode("N76RS", "SW46TA"),
                        CoordinateFrom = new Coordinate(51.472716, -0.12278),
                        CoordinateTo = new Coordinate(51.560414, -0.116805),
                        Distance = new Distance(kilometers: 9.75986360006257, miles: 6.0644980812446372),
                        CreatedAt = DateTime.UtcNow
                    },
                    new LatestSearchHistoriesViewModel(){
                        PostCode = new PostCode("SW46TA", "OX49 5NU"),
                        CoordinateFrom = new Coordinate(51.655929, -1.069752),
                        CoordinateTo = new Coordinate(51.472716, -0.12278),
                        Distance = new Distance(kilometers: 68.550395911181, miles: 42.5952412356718),
                        CreatedAt = DateTime.UtcNow
                    },
                    new LatestSearchHistoriesViewModel(){
                        PostCode = new PostCode("SW46TA", "OX49 5NU"),
                        CoordinateFrom = new Coordinate(51.560414,-0.116805),
                        CoordinateTo = new Coordinate(51.472716, -0.12278),
                        Distance = new Distance(kilometers: 9.75986360006257, miles: 6.764498081244637),
                        CreatedAt = DateTime.UtcNow
                    },
                },
                TotalItems = 3
            };

            var query = new GetLatestSearchHistoriesQuery();

            _searchHistoryRepositoryMock.Setup(x => x.GetSearchHistoriesAsync(query, default)).ReturnsAsync(expected);

            var handler = new SearchHistoryHandler(_searchHistoryRepositoryMock.Object, _unitOfWorkMock.Object, _mapsServiceMock.Object);

            // Act
            PagedList<LatestSearchHistoriesViewModel> result = await handler.Handle(query, default);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Should get search history by id")]
        [Trait("Find", "Get by id")]
        public async Task Handle_Should_Get_SearchHistoryById()
        {
            // Arrange
            var expected = new DistanceViewModel()
            {
                PostcodeFrom = "N76RS",
                PostcodeTo = "SW46TA",
                Distance = new Distance(kilometers: 9.75986360006257, miles: 6.0644980812446372)
            };

            var query = new GetDistanceQuery(1);

            _searchHistoryRepositoryMock.Setup(x => x.GetDistanceByIdAsync(query.Id, default)).ReturnsAsync(expected);

            var handler = new SearchHistoryHandler(_searchHistoryRepositoryMock.Object, _unitOfWorkMock.Object, _mapsServiceMock.Object);

            // Act 
            DistanceViewModel? result = await handler.Handle(query, default);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Should return null when search history not existed")]
        [Trait("Find", "Get by id not existed")]
        public async Task Handle_Should_ReturnNull_WhenSearchHistoryNotExisted()
        {
            // Arrange
            var query = new GetDistanceQuery(1);

            _searchHistoryRepositoryMock.Setup(x => x.GetDistanceByIdAsync(query.Id, default)).ReturnsAsync((DistanceViewModel?)null);

            var handler = new SearchHistoryHandler(_searchHistoryRepositoryMock.Object, _unitOfWorkMock.Object, _mapsServiceMock.Object);
            // Act 
            DistanceViewModel? result = await handler.Handle(query, default);

            // Assert
            Assert.Null(result);
        }
    }
}
