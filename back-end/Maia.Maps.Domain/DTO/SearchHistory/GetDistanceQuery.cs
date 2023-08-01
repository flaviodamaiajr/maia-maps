using MediatR;

namespace Maia.Maps.Domain.DTO.SearchHistory
{
    public record GetDistanceQuery : IRequest<DistanceViewModel>
    {
        public long Id { get; }

        public GetDistanceQuery(long id)
        {
            Id = id;
        }
    }
}
