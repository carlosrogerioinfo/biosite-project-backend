using Biosite.Gateway.Api.Services.Biomarker;
using Biosite.Core.Controller;
using Biosite.Core.Response;
using Biosite.Domain.Commands.Response;
using Microsoft.AspNetCore.Mvc;
using Biosite.Domain.Commands.Request.Biomarker;

namespace Biosite.Gateway.Controllers
{
    [ApiController]
    public class BiomarkerController : BaseController
    {
        private readonly BiomarkerService _service;

        public BiomarkerController(BiomarkerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna as informações do biomarcador pelo Id (requer autenticação).
        /// </summary>
        /// <response code="200">As informações ddo biomarcador que retornou com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("biomarker/get-by-id/{id}")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await Response(await _service.GetById(id, Request.Headers["Authorization"]), _service.Notifications);
        }

        /// <summary>
        /// Retorna todos os biomarcadores (requer autenticação).
        /// </summary>
        /// <response code="200">A lista dos biomarcadores que foram retornadas com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("biomarker/get")]
        [ProducesResponseType(typeof(IEnumerable<BiomarkerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Get()
        {
            return await Response(await _service.GetAll(Request.Headers["Authorization"]), _service.Notifications);
        }

        /// <summary>
        /// Retorna o biomarcador pelo nome (requer autenticação).
        /// </summary>
        /// <response code="200">As informações do biomarcador que foram retornadas com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("biomarker/get-by-name/{name}")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetByName(string name)
        {
            return await Response(await _service.GetByName(name, Request.Headers["Authorization"]), _service.Notifications);
        }
        
        /// <summary>
        /// Insere um biomarcador (requer autenticação).
        /// </summary>
        /// <response code="200">As informações do biomarcador inserido com sucesso.</response>
        /// <response code="412">Ocorreu um erro interno na inclusão.</response>
        [HttpPost]
        [Route("biomarker/save")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Post([FromBody] RegisterBiomarkerRequest command)
        {
            return await Response(await _service.Save(command, Request.Headers["Authorization"]), _service.Notifications);
        }

        /// <summary>
        /// Atualiza um biomarcador (requer autenticação).
        /// </summary>
        /// <response code="200">As informações do biomarcador atualizado com sucesso.</response>
        /// <response code="412">Ocorreu um erro interno na inclusão.</response>
        [HttpPut]
        [Route("biomarker/put")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Put([FromBody] UpdateBiomarkerRequest command)
        {
            return await Response(await _service.Put(command, Request.Headers["Authorization"]), _service.Notifications);
        }

        /// <summary>
        /// Remove um biomarcador (requer autenticação).
        /// </summary>
        /// <response code="200">As informações do biomarcador removido com sucesso.</response>
        /// <response code="412">Ocorreu um erro interno na inclusão.</response>
        [HttpDelete]
        [Route("biomarker/delete")]
        [ProducesResponseType(typeof(BiomarkerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> Delete([FromQuery] DeleteBiomarkerRequest command)
        {
            return await Response(await _service.Delete(command, Request.Headers["Authorization"]), _service.Notifications);
        }
        
    }
}