using Maia.Maps.Domain.DTO;
using Maia.Maps.Domain.DTO.SearchHistory;
using Maia.Maps.Domain.Entities;

namespace Maia.Maps.Domain.Interfaces.Repositories
{
    public interface ISearchHistoryRepository : IBaseRepository<SearchHistory>
    {
        Task<PagedList<LatestSearchHistoriesViewModel>> GetSearchHistoriesAsync(GetLatestSearchHistoriesQuery latestHistorySearchesQuery, CancellationToken cancellationToken = default);
        Task<DistanceViewModel?> GetDistanceByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
