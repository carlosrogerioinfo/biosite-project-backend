using Biosite.Gateway.Api.Services.Organ;
using Biosite.Core.Controller;
using Biosite.Core.Response;
using Biosite.Domain.Commands.Response;
using Microsoft.AspNetCore.Mvc;

namespace Biosite.Gateway.Controllers
{
    [ApiController]
    public class OrganController : BaseController
    {
        private readonly OrganService _service;

        public OrganController(OrganService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna as informações dos órgãos (requer autenticação).
        /// </summary>
        /// <response code="200">As informações dos órgãos retornados com sucesso.</response>
        /// <response code="412">Ocorreu uma falha de pre-condição ou um algum erro interno.</response>
        [HttpGet]
        [Route("organs/get")]
        [ProducesResponseType(typeof(IEnumerable<OrganResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status412PreconditionFailed)]
        public async Task<IActionResult> GetAll()
        {
            return await Response(await _service.GetAll(Request.Headers["Authorization"]), _service.Notifications);
        }
    }
}