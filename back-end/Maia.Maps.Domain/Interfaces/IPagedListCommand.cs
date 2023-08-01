namespace Maia.Maps.Domain.Interfaces
{
    public interface IPagedListCommand
    {
        int Page { get; }
        int PageSize { get; }
    }
}
