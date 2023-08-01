namespace Maia.Maps.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
