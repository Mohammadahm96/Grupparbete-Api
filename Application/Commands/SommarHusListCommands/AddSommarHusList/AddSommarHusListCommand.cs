using Application.Dto;
using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.SommarHusLists.AddSommarHusList
{
    public class AddSommarHusListCommand : IRequest<SommarHusArticleList>
    {
        public AddSommarHusListCommand(AddNewSommarHusDto newSommarHusList)
        {
            NewSommarHusList = newSommarHusList;
        }

        public AddNewSommarHusDto NewSommarHusList { get; set; }
    }
}
