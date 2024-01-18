using Application.Dto;
using Domain.Models.ListModels;
using MediatR;

namespace Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList
{
    public class AddArticleToFamilyShoppingListCommand : IRequest<FamilyArticleList>
    {
        public AddArticleToFamilyShoppingListCommand(FamilyShoppingListDto newFamilyShoppingList)
        {
            NewFamilyShoppingList = newFamilyShoppingList;
        }

        public FamilyShoppingListDto NewFamilyShoppingList { get; }
    }
}