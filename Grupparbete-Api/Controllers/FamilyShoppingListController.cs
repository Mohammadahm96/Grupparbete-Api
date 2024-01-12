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

        //[HttpPost]
        //[Route("addNewArticle")]
        //public async Task<IActionResult> AddArticle([FromBody] FamilyShoppingListDto newFamilyShoppingList)
        //{
        //    return Ok(await _mediator.Send(new AddFamilyShoppingListCommand(newFamilyShoppingList)));
        //}
    }
}