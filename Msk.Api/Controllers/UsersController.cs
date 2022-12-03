using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msk.Service.Users.Commands;

namespace Msk.Api.Controllers
{
    [Route("api/v1/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(UserCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        

    }
}
