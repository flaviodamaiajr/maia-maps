using Maia.Maps.Domain.DTO;
using Maia.Maps.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Maia.Maps.Infra.Data.Extensions
{
    public static class QueryExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, IPagedListCommand command, CancellationToken cancellationToken) where T : class
        {
            return new PagedList<T>
            {
                Items = await query.Skip((command.Page - 1) * command.PageSize).Take(command.PageSize).ToListAsync(cancellationToken: cancellationToken),
                TotalItems = await query.LongCountAsync(cancellationToken)
            };
        }
    }
}
