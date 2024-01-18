using Application.Dto;
using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.SommarHusListCommands.UpdateSommarHusList
{
    public class UpdateSommarHusListByIdCommand : IRequest<SommarHusArticleList>
    {
        public UpdateSommarHusListByIdCommand(Guid id, SommarHusListDto updatedSommarHusList)
        {

            Id = id;
            SommarHusListToUpdate = updatedSommarHusList;
        }
        public SommarHusListDto SommarHusListToUpdate { get; }
        public Guid Id { get; }
    }
}