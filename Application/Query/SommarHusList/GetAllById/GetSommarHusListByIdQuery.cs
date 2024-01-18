using Domain.Models.ListModels;
using MediatR;

namespace Application.Query.SommarHusList.GetById
{
    public class GetSommarHusListByIdQuery : IRequest<SommarHusArticleList>
    {
        public GetSommarHusListByIdQuery(Guid sommarHusListId)
        {
            Id = sommarHusListId;
        }

        public Guid Id { get; }
    }
}
