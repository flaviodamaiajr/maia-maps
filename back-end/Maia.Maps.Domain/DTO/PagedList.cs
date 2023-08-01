namespace Maia.Maps.Domain.DTO
{
    public record PagedList<T>
    {
        public long TotalItems { get; init; }
        public List<T> Items { get; init; } = new List<T>();
    }
}
