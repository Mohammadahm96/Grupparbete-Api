using MediatR;
using Application.Dto;

namespace Application.Commands.FamilyShoppingListCommands.AddFamilyList
{
    public class AddFamilyCommand : IRequest<Guid>
    {
        public AddNewFamilyDto FamilyDto { get; }

        public AddFamilyCommand(AddNewFamilyDto familyDto)
        {
            FamilyDto = familyDto;
        }
    }
}