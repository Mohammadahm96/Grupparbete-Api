using MediatR;

namespace Application.Query.FamilyArticleQuery
{
    public class GetAllArticlesByFamilyIdQuery : IRequest<List<string>>
    {
        public Guid FamilyId { get; set; }

        public GetAllArticlesByFamilyIdQuery(Guid familyId)
        {
            FamilyId = familyId;
        }
    }
}
