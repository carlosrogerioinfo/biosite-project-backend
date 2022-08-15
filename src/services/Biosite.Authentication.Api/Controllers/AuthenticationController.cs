using Biosite.Authentication.Api.Commands.Handlers;
using Biosite.Core.Commands.Response;
using Biosite.Core.Constants;
using Biosite.Core.Controller;
using Biosite.Core.JwtBearerToken.Service;
using Biosite.Core.Response;
using Biosite.Domain.Commands.Request.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Api.Controllers
{
    [Authorize(Roles = Constants.AdminProj)]
    public class AuthenticationController : BaseController
    {
        private readonly UserCommandHandler _handler;
        private readonly IJwtService _service;

        public AuthenticationController(UserCommandHandler handler, IJwtService service)
            : base()
        {
            _handler = handler;
            _service = service;
        }

        /// <summary>
        /// Retorna as informações do(a) usuário(a) pelo email e senha.
        /// </summary>
        /// <response code="200">As informações do(a) usuário(a) que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post([FromBody] AuthenticateUserRequest command)
        {
            var data = await _handler.Handle(command.Email, command.Password);

            if (data != null)
            {
                data.Token = _service.GenerateToken(data);

                var response = new
                {
                    token = data.Token,
                    refreshToken = Guid.NewGuid() //"not implemented yet"
                };

                return await Response(response, _handler.Notifications);
            }

            return await Response(data, _handler.Notifications);

        }
    }
}
