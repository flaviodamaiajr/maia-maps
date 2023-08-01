using Maia.Maps.Domain.Interfaces;
using MediatR;

namespace Maia.Maps.Domain.DTO.SearchHistory
{
    public record GetLatestSearchHistoriesQuery : IRequest<PagedList<LatestSearchHistoriesViewModel>>, IPagedListCommand
    {
        public int Page => 1;
        public int PageSize => 3;
    }
}