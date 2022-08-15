using Biosite.Biomarkers.Api.Commands.Handlers;
using Biosite.Core.Constants;
using Biosite.Core.Controller;
using Biosite.Core.Response;
using Biosite.Domain.Commands.Request.Biomarker;
using Biosite.Domain.Commands.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Biomarkers.Api.Controllers
{
    [Authorize(Roles = Constants.BiomarkerPlan)]
    public class BiomarkerController : BaseController
    {
        private readonly BiomarkerCommandHandler _handler;

        public BiomarkerController(BiomarkerCommandHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Retorna as informações do biomarcador pelo Id (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações ddo biomarcador que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("biomarker/get-by-id/{id}")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new SelectBiomarkerByIdRequest
            {
                Id = id
            };

            var data = await _handler.Handle(request);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        #region 'BIOMARKER OPERATIONS CRUD'

        /// <summary>
        /// Retorna todos os biomarcadores (acesso exclusivo).
        /// </summary>
        /// <response code="200">A lista dos biomarcadores que foram retornadas com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("biomarker/crud/get")]
        [ProducesResponseType(typeof(IEnumerable<BiomarkerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Get()
        {
            var data = await _handler.Handle();
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Retorna o biomarcador pelo nome (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do biomarcador que foram retornadas com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpGet]
        [Route("biomarker/crud/get-by-name/{name}")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetByName(string name)
        {
            var request = new SelectBiomarkerByNameRequest
            {
                Name = name
            };

            var data = await _handler.Handle(request);

            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Insere um biomarcador (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do biomarcador inserido com sucesso.</response>
        /// <response code="412">Ocorreu um erro interno na inclusão.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpPost]
        [Route("biomarker/crud/save")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post([FromBody] RegisterBiomarkerRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Atualiza um biomarcador (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do biomarcador atualizado com sucesso.</response>
        /// <response code="412">Ocorreu um erro interno na inclusão.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpPut]
        [Route("biomarker/crud/put")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Put([FromBody] UpdateBiomarkerRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        /// <summary>
        /// Remove um biomarcador (acesso exclusivo).
        /// </summary>
        /// <response code="200">As informações do biomarcador removido com sucesso.</response>
        /// <response code="412">Ocorreu um erro interno na inclusão.</response>
        [Authorize(Roles = Constants.AdminProj)]
        [HttpDelete]
        [Route("biomarker/crud/delete")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Delete([FromQuery] DeleteBiomarkerRequest command)
        {
            var data = await _handler.Handle(command);
            if (data != null)
                return await Response(data, _handler.Notifications);

            return await Response(data, _handler.Notifications);
        }

        #endregion
    }
}
