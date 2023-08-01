using Maia.Maps.Domain.Entities;
using Maia.Maps.Domain.ValuesObjects;
using Maia.Maps.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Maia.Maps.Api.Tests
{
    public class MapsMockData
    {
        public static async Task CreateSearchHistoryMockData(ApiApplication application, bool create)
        {
            using var scope = application.Services.CreateScope();

            var provider = scope.ServiceProvider;

            using var dbContext = provider.GetRequiredService<MaiaContext>();

            var status = await dbContext.Database.EnsureCreatedAsync();

            if (create)
            {
                dbContext.SearchHistories.Add(
                    new SearchHistory(
                    new PostCode("N76RS", "SW46TA"),
                    new Coordinate(1.560414, -0.116805),
                    new Coordinate(51.472716, -0.12278)));


                dbContext.SearchHistories.Add(
                    new SearchHistory(
                        new PostCode("N76RS", "SW46TA"),
                    new Coordinate(1.560414, -0.116805),
                    new Coordinate(51.560414, -0.116805)));

                dbContext.SearchHistories.Add(
                    new SearchHistory(
                    new PostCode("W1B3AG", "SW46TA"),
                    new Coordinate(1.560414, -0.116805),
                    new Coordinate(51.514956, -0.141553)));


                dbContext.SearchHistories.Add(new SearchHistory(
                    new PostCode("PO63TD", "SW46TA"),
                    new Coordinate(1.560414, -0.116805),
                    new Coordinate(50.846019, -1.086124)));


                dbContext.SearchHistories.Add(new SearchHistory(
                    new PostCode("OX49 5NU", "M32 0JG"),
                    new Coordinate(51.655929, -1.069752),
                    new Coordinate(53.455654, -2.302836)));

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
