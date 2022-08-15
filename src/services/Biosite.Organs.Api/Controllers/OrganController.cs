using Biosite.Core.Constants;
using Biosite.Core.Controller;
using Biosite.Core.Response;
using Biosite.Domain.Commands.Request.Organ;
using Biosite.Domain.Commands.Response;
using Biosite.Organs.Api.Commands.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Organs.Api.Controllers
{
    [Authorize(Roles = Constants.AllPlan)]
    public class OrganController : BaseController
    {
        private readonly OrganCommandHandler _handler;
        private readonly Random _random = new Random();

        public OrganController(OrganCommandHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Retorna as informações do orgão pelo Id.
        /// </summary>
        /// <response code="200">As informações do orgão que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("organ/get-by-id/{id}")]
        [ProducesResponseType(typeof(OrganResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetOrganById(Guid id)
        {
            var request = new SelectOrganByIdRequest
            {
                Id = id
            };

            var data = await _handler.Handle(request);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        #region 'ORGAN OPERATIONS CRUD'

        /// <summary>
        /// Retorna todos os orgãos. (acesso exclusivo)
        /// </summary>
        /// <response code="200">A lista dos orgãos que foram retornados com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpGet]
        [Route("organ/crud/get")]
        [ProducesResponseType(typeof(IEnumerable<OrganResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetAll()
        {
            var data = await _handler.Handle();
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Retorna as informações do orgão pelo nome. (acesso exclusivo)
        /// </summary>
        /// <response code="200">As informações do orgão que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpGet]
        [Route("organ/crud/get-by-name/{name}")]
        [ProducesResponseType(typeof(OrganResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetAllOrganByName(string name)
        {
            var request = new SelectOrganByNameRequest
            {
                Name = name
            };

            var data = await _handler.Handle(request);

            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Cadastra um orgãos (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do orgão que foi cadastrado com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpPost]
        [Route("organ/crud/save")]
        [ProducesResponseType(typeof(OrganResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post([FromBody] RegisterOrganRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Atualiza um orgãos (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do orgão que foi atualizado com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpPut]
        [Route("organ/crud/put")]
        [ProducesResponseType(typeof(OrganResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Put([FromBody] UpdateOrganRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Deleta um orgãos pelo Id (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do orgão que foi deletado com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpDelete]
        [Route("organ/crud/delete")]
        [ProducesResponseType(typeof(OrganResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Delete([FromBody] DeleteOrganRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        #endregion
    }
}
