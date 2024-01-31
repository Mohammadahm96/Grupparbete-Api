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

                // Add FamilyName as the first element in the result list
                List<string> result = new List<string> { sommarhusName };

                // Add each ArticleName separately to the result list
                result.AddRange(articleNames);

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                throw;
            }
        }
    }
}