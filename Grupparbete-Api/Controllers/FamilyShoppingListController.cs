using Application.Commands.FamilyShoppingListCommands;
using Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Grupparbete_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyShoppingListController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public FamilyShoppingListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addNewArticle")]
        public async Task<IActionResult> AddArticle([FromBody] FamilyShoppingListDto newFamilyShoppingList, [FromQuery] Guid familyId)
        {

            if (familyId == Guid.Empty)
            {
                return BadRequest("FamilyId is required to add an article to the family shopping list.");
            }

            newFamilyShoppingList.FamilyId = familyId;

            return Ok(await _mediator.Send(new AddArticleToFamilyShoppingListCommand(newFamilyShoppingList)));
        }
    }
}