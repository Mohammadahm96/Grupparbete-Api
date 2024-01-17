using Application.Query.SommarHusList.GetAll;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Queries.SommarHusList.GetAll
{
    public class GetAllSommarHusListQueryHandler : IRequestHandler<GetAllSommarHusListQuery, List<SommarHusArticleList>>
    {
        private readonly ISommarHusListRepository _sommarHusListRepository;

        public GetAllSommarHusListQueryHandler(ISommarHusListRepository sommarHusListRepository)
        {
            _sommarHusListRepository = sommarHusListRepository;
        }
        public async Task<List<SommarHusArticleList>> Handle(GetAllSommarHusListQuery request, CancellationToken cancellationToken)
        {
            List<SommarHusArticleList> allSommarHusListFromMyDbContext = await _sommarHusListRepository.GetAllSommarHusListAsync();
            return allSommarHusListFromMyDbContext;
        }
    }
}
