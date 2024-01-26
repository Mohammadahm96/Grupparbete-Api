using Infrastructure.Interface;
using MediatR;

namespace Application.Query.FamilyArticleQuery
{
    public class GetAllArticlesByFamilyIdQueryHandler : IRequestHandler<GetAllArticlesByFamilyIdQuery, List<string>>
    {
        private readonly IArticleRepository _articleRepository;

        public GetAllArticlesByFamilyIdQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<string>> Handle(GetAllArticlesByFamilyIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string familyName = await _articleRepository.GetFamilyNameAsync(request.FamilyId);
                List<string> articleNames = await _articleRepository.GetArticleNamesByFamilyIdAsync(request.FamilyId);

                // Add FamilyName as the first element in the result list
                List<string> result = new List<string> { familyName };

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
