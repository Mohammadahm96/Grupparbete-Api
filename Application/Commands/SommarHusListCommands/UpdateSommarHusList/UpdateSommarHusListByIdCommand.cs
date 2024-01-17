using Application.Dto;
using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.SommarHusListCommands.UpdateSommarHusList
{
    public class UpdateSommarHusListByIdCommand : IRequest<SommarHusArticleList>
    {
        public UpdateSommarHusListByIdCommand(Guid id, SommarHusListDto updatedSommarHusArticleList)
        {

            Id = id;
            SommarHusArticleListToUpdate = updatedSommarHusArticleList;
        }
        public SommarHusListDto SommarHusArticleListToUpdate { get; }
        public Guid Id { get; }
    }
}