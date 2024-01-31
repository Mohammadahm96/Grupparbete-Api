using MediatR;
using Domain.Models.ListModels;
using Application.Dto;

namespace Application.Commands.FamilyShoppingListCommands.DeleteFamilyShoppingList
{
    public class DeleteArticleFromFamilyShoppingListCommand : IRequest<FamilyArticleList>
    {
        public DeleteArticleFromFamilyShoppingListCommand(DeleteArticleFromFamilyShoppingListDto deleteFamilyShoppingListDto)
        {
            DeleteFamilyShoppingListDto = deleteFamilyShoppingListDto;
        }

        public DeleteArticleFromFamilyShoppingListDto DeleteFamilyShoppingListDto { get; }
    }
}
