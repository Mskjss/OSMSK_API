using MediatR;
using Microsoft.AspNetCore.Mvc;
using Msk.Domain.Users;

namespace Msk.Api.Controllers
{
    [Route("api/vi/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("login-email")]
        public IActionResult LoginEmail([FromBody] string loginemail)
        {
            return Ok();
        }
        [HttpPost, Route("login-cell")]
        public IActionResult LoginCell([FromBody] string loginecell)
        {
            return Ok();
        }

    }
}
