using Authentication.Gateway.Api.Request;
using Authentication.Gateway.Api.Services.Authentication;
using Biosite.Core.Commands.Response;
using Biosite.Core.Controller;
using Biosite.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Gateway.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly AuthenticationService _service;

        public AuthenticationController(AuthenticationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna as informações do usuário e do token para autenticação nos endpoint que requerem autorização para acessar.
        /// </summary>
        /// <response code="200">As informações do usuário e token que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpPost]
        [Route("authentication/login")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest requestCommand)
        {
            return await Response(await _service.Authentication(requestCommand), _service.Notifications);
        }

    }
}
