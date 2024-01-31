using Infrastructure.Interfaces;
using MediatR;

namespace Application.Query.SommarHusList.GetAll
{
    public class GetFamilySommarHusArticlesQueryHandler : IRequestHandler<GetFamilySommarHusArticlesQuery, List<string>>
    {
        private readonly ISommarHusListRepository _sommarHusListRepository;

        public GetFamilySommarHusArticlesQueryHandler(ISommarHusListRepository sommarHusListRepository)
        {
            _sommarHusListRepository = sommarHusListRepository;
        }

        public async Task<List<string>> Handle(GetFamilySommarHusArticlesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string sommarhusName = await _sommarHusListRepository.GetHouseNameAsync(request.SommarHusId);
                List<string> articleNames = await _sommarHusListRepository.GetArticleNamesBySommarHusIdAsync(request.SommarHusId);

                List<string> result = new List<string> { sommarhusName };

                result.AddRange(articleNames);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}