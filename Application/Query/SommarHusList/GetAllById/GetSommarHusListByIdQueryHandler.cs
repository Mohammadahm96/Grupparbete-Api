using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Query.SommarHusList.GetById
{
    public class GetSommarHusListByIdQueryHandler : IRequestHandler<GetSommarHusListByIdQuery, SommarHusArticleList>
    {
        private readonly ISommarHusListRepository _sommarHusListRepository;

        public GetSommarHusListByIdQueryHandler(ISommarHusListRepository sommarHusListRepository)
        {
            _sommarHusListRepository = sommarHusListRepository;
        }
        public async Task<SommarHusArticleList> Handle(GetSommarHusListByIdQuery request, CancellationToken cancellationToken)
        {
            SommarHusArticleList? wantedSommarHus = await _sommarHusListRepository.GetSommarHusListByIdAsync(request.Id);
            if (wantedSommarHus == null)
            {
                throw new KeyNotFoundException($"No sommarHus found with the id {request.Id}");
            }
            return wantedSommarHus;
        }
    }
}
