﻿using Application.Commands.SommarHusListCommands.AddArticleSommarhusList;
using Application.Commands.SommarHusListCommands.UpdateSommarHusList;
using Application.Commands.SommarHusLists.AddSommarHusList;
using Application.Commands.SommarHusLists.DeleteSommarHusList;
using Application.Dto;
using Application.Query.SommarHusList.GetAll;
using Application.Query.SommarHusList.GetAllById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grupparbete_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SommarHusListController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public SommarHusListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getArticlesByFamilyId")]
        public async Task<IActionResult> GetArticleNamesBySommarHusIdAsync([FromQuery] Guid sommarhusid)
        {
            try
            {
                if (sommarhusid == Guid.Empty)
                {
                    return BadRequest("FamilyId is required to retrieve articles for the family shopping list.");
                }

                var query = new GetFamilySommarHusArticlesQuery(sommarhusid);
                var articleNames = await _mediator.Send(query);

                return Ok(articleNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while trying to retrieve articles for the family.");
            }
        }

        ////Get Sommarhuslist By Id
        //    [HttpGet]
        //    [Route("getSommarHusListById/{sommarHusArticleId}")]
        //    public async Task<IActionResult> GetSommarHusListById(Guid sommarHusArticleId)
        //    {
        //        return Ok(await _mediator.Send(new GetSommarHusListByIdQuery(sommarHusArticleId)));
        //    }

        //Create a new SommarHus
        [HttpPost]
        [Route("addNewSommarHusList")]
        public async Task<IActionResult> AddSommarHusList([FromBody] AddNewSommarHusDto newSommarHusList)
        {
            return Ok(await _mediator.Send(new AddSommarHusListCommand(newSommarHusList)));
        }
        [HttpPost]
        [Route("addNewArticle")]
        public async Task<IActionResult> AddArticle([FromBody] SommarHusListDto newSommarHusList, [FromQuery] Guid sommarHusId)
        {

            if (sommarHusId == Guid.Empty)
            {
                return BadRequest("SommarHusId is required to add an article to the sommarHus shopping list.");
            }

            newSommarHusList.SommarHusId = sommarHusId;

            return Ok(await _mediator.Send(new AddArticleToSommarHusShoppingListCommand(newSommarHusList)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSommarHusListById(Guid id)
        {
            var sommarHusList = await _mediator.Send(new DeleteSommarHusListByIdCommand(id));
            if (sommarHusList != null)
            {
                return Ok($"SommarHus with Id {id} has been successfully deleted.");
            }
            return NotFound();
        }

        //Update a specific SommarHus
        [HttpPut]
        [Route("updateSommarHusList/{updateSommarHusListId}")]
        public async Task<IActionResult> UpdateSommarHusList([FromBody] SommarHusListDto updatedSommarHusList, Guid updateSommarHusListId)
        {
            return Ok(await _mediator.Send(new UpdateSommarHusListByIdCommand(updateSommarHusListId, updatedSommarHusList)));
        }

        [Authorize]
        [HttpGet("sommarhusidandnames")]
        public async Task<ActionResult<List<object>>> GetSommarHusIdAndNames()
        {
            var query = new GetSommarHusIdAndNamesQuery();
            var result = await _mediator.Send(query);

            return Ok(result.Cast<object>().ToList());
        }
    }
}