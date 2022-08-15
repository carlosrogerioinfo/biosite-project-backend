using Biosite.Core.Controller;
using Biosite.Core.Response;
using Biosite.Domain.Commands.Request.User;
using Biosite.Gateway.Api.Response;
using Biosite.Gateway.Api.Services.Profile;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Gateway.Controllers
{
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly ProfileService _service;

        public ProfileController(ProfileService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna as informações do perfil do usuário logado (requer autenticação).
        /// </summary>
        /// <response code="200">Informações do perfil do usuário retornados com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("profile/get/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ProfileResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetAll(Guid id)
        {
            return await Response(await _service.GetById(id, Request.Headers["Authorization"]), _service.Notifications);
        }

        /// <summary>
        /// Retorna as informações do perfil pelo email e senha.
        /// </summary>
        /// <response code="200">As informações perfil que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpPost]
        [Route("profile/info")]
        [ProducesResponseType(typeof(ProfileResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Info([FromBody] AuthenticateUserRequest requestCommand)
        {
            return await Response(await _service.ProfileInfo(requestCommand, Request.Headers["Authorization"]), _service.Notifications);
        }

        /// <summary>
        /// Retorna alterações do perfil do usuário (requer autenticação).
        /// </summary>
        /// <response code="200">Alterações do perfil do usuário realizado com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpPut]
        [Route("profile/put")]
        [ProducesResponseType(typeof(IEnumerable<ProfileResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Put([FromBody] UpdateProfileRequest command)
        {
            return await Response(await _service.Put(command, Request.Headers["Authorization"]), _service.Notifications);
        }
    }
}