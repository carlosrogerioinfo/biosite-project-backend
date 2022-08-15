using Biosite.Profile.Api.Commands.Handlers;
using Biosite.Core.Commands.Response;
using Biosite.Core.Constants;
using Biosite.Core.Controller;
using Biosite.Core.Response;
using Biosite.Domain.Commands.Request.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Biosite.Domain.Commands.Request.Profile;

namespace Biosite.Api.Controllers
{
    [Authorize(Roles = Constants.AllPlan)]
    public class ProfileController : BaseController
    {
        private readonly ProfileCommandHandler _handler;

        public ProfileController(ProfileCommandHandler handler)
            : base()
        {
            _handler = handler;
        }

        /// <summary>
        /// Retorna as informações do perfil do usuário logado (acesso exclusivo).
        /// </summary>
        /// <response code="200">Informações do perfil do usuário retornados com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet, Route("profile/get/{id}")]
        [ProducesResponseType(typeof(ProfileResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new SelectUserByIdRequest { Id = id };
            var data = await _handler.Handle(request.Id);

            var response = new
            {
                id = data.Id,
                name = data.Name,
                email = data.Email,
                age = data.Age,
                genderDescription = data.GenderDescription,
                pregnant = data.IsPregnant,
                height = data.Height,
                weight = Math.Round(data.Weight, 2),
                imc = data.Imc,
                imcResult = data.ImcResult,
                lastLoginAt = data.LastLoginDate.ToString("dd/MM/yyyy HH:mm"),
                plan = data.PlanResponse,
            };

            if (data != null)
                return await Response(response, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Retorna as informações do perfil pelo email e senha.
        /// </summary>
        /// <response code="200">As informações perfil que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpPost, Route("profile/info")]
        [ProducesResponseType(typeof(ProfileResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Info([FromBody] AuthenticateUserRequest command)
        {
            var data = await _handler.Handle(command.Email, command.Password);

            if (data != null)
            {
                return await Response(data, _handler.Notifications);
            }

            return await Response(data, _handler.Notifications);
        }
        
        /// <summary>
        /// Retorna alterações do perfil do usuário (acesso exclusivo).
        /// </summary>
        /// <response code="200">Alterações do perfil do usuário realizado com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [Authorize(Roles = Constants.AllPlan)]
        [HttpPut, Route("profile/put")]
        [ProducesResponseType(typeof(IEnumerable<ProfileResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> PutProfile([FromBody] UpdateProfileRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }
    }
}
