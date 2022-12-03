using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Msk.Api.Controllers
{
    [Route("api/v1/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("register-company-cpf")]
        public IActionResult RegisterCompanyCpf([FromBody] string command)
        {
            return Ok();
        }
        [HttpPost, Route("register-company-cnpj")]
        public IActionResult RegisterCompanyCnpj([FromBody] string command)
        {
            return Ok();
        }
    }
}
