using Application.Commands.FamilyShoppingListCommands.AddFamilyList;
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
        [HttpPost]
        [Route("addNewFamily")]
        public async Task<IActionResult> AddFamily([FromBody] AddNewFamilyDto newFamilyDto)
        {
            try
            {
                var addFamilyCommand = new AddFamilyCommand(newFamilyDto);
                var familyId = await _mediator.Send(addFamilyCommand);

                return Ok(new { FamilyId = familyId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while trying to add a family.");
            }
        }

    }
}