using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.SommarHusLists.DeleteSommarHusList
{
    public class DeleteSommarHusListByIdCommand : IRequest<SommarHusArticleList>
    {
        public DeleteSommarHusListByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
