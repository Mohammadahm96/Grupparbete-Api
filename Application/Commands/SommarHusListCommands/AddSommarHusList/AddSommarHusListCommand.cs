using Application.Dto;
using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.SommarHusLists.AddSommarHusList
{
    public class AddSommarHusListCommand : IRequest<SommarHusArticleList>
    {
        public AddSommarHusListCommand(SommarHusListDto newSommarHusList)
        {
            NewSommarHusList = newSommarHusList;
        }

        public SommarHusListDto NewSommarHusList { get; set; }
    }
}
