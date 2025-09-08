using System.Net;
using IntegraBrasilApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBrasilApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PortalTransparenciaController : ControllerBase
    {
        private readonly IPortalTransparenciaService _service;

        public PortalTransparenciaController(IPortalTransparenciaService service)
        {
            _service = service;
        }

        [HttpGet("cepim/{cpfCnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultarCepim(string cpfCnpj)
        {
            var response = await _service.ConsultarCepim(cpfCnpj);

            if (response.CodigoHttp == HttpStatusCode.OK)
                return Ok(response.DadosRetorno);
            else
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }

        [HttpGet("peps/{cpfCnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultarPeps(string cpfCnpj)
        {
            var response = await _service.ConsultarPeps(cpfCnpj);

            if (response.CodigoHttp == HttpStatusCode.OK)
                return Ok(response.DadosRetorno);
            else
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}