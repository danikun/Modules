using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.A.Application;

namespace Module.A.Api.Controllers
{
    [ApiController]
    [Route("api/a")]
    public class AController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetEntities()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string name)
        {
            await _mediator.Send(new AddEntity(name));
            return Ok();
        }
    }
}