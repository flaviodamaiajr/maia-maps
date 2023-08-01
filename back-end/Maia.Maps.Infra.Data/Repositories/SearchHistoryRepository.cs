using Maia.Maps.Domain.DTO;
using Maia.Maps.Domain.DTO.SearchHistory;
using Maia.Maps.Domain.Entities;
using Maia.Maps.Domain.Interfaces.Repositories;
using Maia.Maps.Infra.Data.Context;
using Maia.Maps.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Maia.Maps.Infra.Data.Repositories
{
    public class SearchHistoryRepository : BaseRepository<SearchHistory>, ISearchHistoryRepository
    {
        private readonly MaiaContext _context;

        public SearchHistoryRepository(MaiaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<LatestSearchHistoriesViewModel>> GetSearchHistoriesAsync(GetLatestSearchHistoriesQuery latestHistorySearchesQuery, CancellationToken cancellationToken = default)
        {
            return await _context.SearchHistories.Select(SelectSearchHistoryViewModel())
                        .AsNoTracking()
                        .OrderByDescending(s => s.CreatedAt)
                        .ToPagedListAsync(latestHistorySearchesQuery, cancellationToken);
        }

        private static Expression<Func<SearchHistory, LatestSearchHistoriesViewModel>> SelectSearchHistoryViewModel()
        {
            return history => new LatestSearchHistoriesViewModel
            {
                Id = history.Id,
                CoordinateFrom = history.CoordinatesFrom,
                CoordinateTo = history.CoordinatesTo,
                CreatedAt = history.CreatedAt,
                Distance = history.Distance!,
                PostCode = history.PostCode
            };
        }

        public async Task<DistanceViewModel?> GetDistanceByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var query = await _context.SearchHistories
                .Where(s => s.Id == id)
                .Select(SelectDistanceViewModel())
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            return query;
        }

        private static Expression<Func<SearchHistory, DistanceViewModel>> SelectDistanceViewModel()
        {
            return distance => new DistanceViewModel
            {
                Distance = distance.Distance!,
                PostcodeFrom = distance.PostCode.From,
                PostcodeTo = distance.PostCode.To,
            };
        }

    }
}
