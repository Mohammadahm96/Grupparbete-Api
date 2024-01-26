using Application.Commands.FamilyShoppingListCommands.AddFamilyList;
using Application.Commands.FamilyShoppingListCommands.AddFamilyShoppingList;
using Application.Commands.FamilyShoppingListCommands.UpdateFamilyShoppingList;
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
        [HttpPut]
        [Route("updateArticle")]
        public async Task<IActionResult> UpdateArticle([FromBody] UpdateFamilyShoppingListDto updateFamilyShoppingListDto, [FromQuery] Guid familyId)
        {
            try
            {
                if (updateFamilyShoppingListDto.FamilyId == Guid.Empty || updateFamilyShoppingListDto.ArticleId == Guid.Empty)
                {
                    return BadRequest("FamilyId and ArticleId are required to update an article in the family shopping list.");
                }

                var command = new UpdateArticleInFamilyShoppingListCommand(updateFamilyShoppingListDto);
                var updatedFamilyList = await _mediator.Send(command);

                return Ok(updatedFamilyList);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }

}
