using MediatR;
using Domain.Models.ListModels;

namespace Application.Query.SommarHusList.GetAll
{
    public class GetAllSommarHusListQuery : IRequest<List<SommarHusArticleList>>
    {
    }
}
