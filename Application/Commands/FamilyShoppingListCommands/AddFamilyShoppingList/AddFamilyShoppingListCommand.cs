using Application.Dto;
using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList
{
    public class AddFamilyShoppingListCommand : IRequest<FamilyArticleList>
    {
        public AddFamilyShoppingListCommand(FamilyShoppingListDto newFamilyShoppingList)
        {
            NewFamilyShoppingLIst = newFamilyShoppingList;
        }

        public FamilyShoppingListDto NewFamilyShoppingLIst { get; }
    }
}