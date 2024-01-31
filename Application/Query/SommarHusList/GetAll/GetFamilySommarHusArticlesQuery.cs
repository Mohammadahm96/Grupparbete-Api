using MediatR;

namespace Application.Query.SommarHusList.GetAll
{
    public class GetFamilySommarHusArticlesQuery : IRequest<List<string>>
    {
        public Guid SommarHusId { get; set; }

        public GetFamilySommarHusArticlesQuery(Guid sommarHusId)
        {
            SommarHusId = sommarHusId;
        }
    }
}