using Maia.Maps.Domain.DTO;
using Maia.Maps.Domain.DTO.SearchHistory;
using Maia.Maps.Domain.Entities;
using Maia.Maps.Domain.Interfaces;
using Maia.Maps.Domain.Interfaces.Repositories;
using Maia.Maps.Domain.Interfaces.Services;
using Maia.Maps.Domain.ValuesObjects;
using MediatR;

namespace Maia.Maps.Domain.Handlers
{
    public class SearchHistoryHandler :
        IRequestHandler<GetLatestSearchHistoriesQuery, PagedList<LatestSearchHistoriesViewModel>>,
        IRequestHandler<GetDistanceQuery, DistanceViewModel?>,
        IRequestHandler<CreateSearchHistoryCommand, Result<SearchDetailsViewModel>>
    {
        private readonly ISearchHistoryRepository _searchHistoryRepository;
        private readonly IMapsService _mapsService;
        private readonly IUnitOfWork _unitOfWork;

        public SearchHistoryHandler(ISearchHistoryRepository searchHistoryRepository, IUnitOfWork unitOfWork, IMapsService mapsService)
        {
            _searchHistoryRepository = searchHistoryRepository;
            _mapsService = mapsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<LatestSearchHistoriesViewModel>> Handle(GetLatestSearchHistoriesQuery request, CancellationToken cancellationToken)
        {
            return await _searchHistoryRepository.GetSearchHistoriesAsync(request, cancellationToken);
        }

        public async Task<DistanceViewModel?> Handle(GetDistanceQuery request, CancellationToken cancellationToken)
        {
            return await _searchHistoryRepository.GetDistanceByIdAsync(request.Id, cancellationToken);
        }

        public async Task<Result<SearchDetailsViewModel>> Handle(CreateSearchHistoryCommand request, CancellationToken cancellationToken)
        {
            var (kilometers, miles) = _mapsService.CalculateDistanceByCoords(request.CoordinatesFrom!, request.CoordinatesTo!);

            var searchHistory = new SearchHistory(
                new PostCode(request.Postcode!.From, request.Postcode!.To),
                new Distance(kilometers, miles),
                request.CoordinatesFrom!,
                request.CoordinatesTo!);

            _searchHistoryRepository.Add(searchHistory);

            var status = await _unitOfWork.CommitAsync(cancellationToken);
            
            return new Result<SearchDetailsViewModel>(status == 1,
                new SearchDetailsViewModel(kilometers, miles),
                message: status != 1 ?
                "Unable to save search history at this time." :
                string.Empty);
        }
    }
}
