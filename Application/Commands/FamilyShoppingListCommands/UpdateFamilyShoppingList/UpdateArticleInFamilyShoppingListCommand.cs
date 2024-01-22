using Application.Dto;
using MediatR;
using Domain.Models.ListModels;

namespace Application.Commands.FamilyShoppingListCommands.UpdateFamilyShoppingList
{
    public class UpdateArticleInFamilyShoppingListCommand : IRequest<FamilyArticleList>
    {
        public UpdateArticleInFamilyShoppingListCommand(UpdateFamilyShoppingListDto updateFamilyShoppingListDto)
        {
            UpdateFamilyShoppingListDto = updateFamilyShoppingListDto;
        }

        public UpdateFamilyShoppingListDto UpdateFamilyShoppingListDto { get; }
    }
}
