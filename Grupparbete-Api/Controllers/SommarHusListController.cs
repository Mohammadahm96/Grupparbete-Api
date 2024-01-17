using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
