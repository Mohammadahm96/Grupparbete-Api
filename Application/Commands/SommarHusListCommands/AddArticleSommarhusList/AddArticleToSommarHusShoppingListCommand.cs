using Application.Dto;
using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.SommarHusListCommands.AddArticleSommarhusList
{
    public class AddArticleToSommarHusShoppingListCommand : IRequest<SommarHusArticleList>
    {
        public AddArticleToSommarHusShoppingListCommand(SommarHusListDto newSommarHusShoppingList)
        {
            NewSommarHusShoppingList = newSommarHusShoppingList;
        }

        public SommarHusListDto NewSommarHusShoppingList { get; }
    }
}
