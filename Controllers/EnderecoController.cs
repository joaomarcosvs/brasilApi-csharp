using System.Net;
using IntegraBrasilApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBrasilApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoController : ControllerBase
    {
        public readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("buscar/{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> BuscarEndereco([FromRoute] string cep)
        {
            var response = await _enderecoService.BuscarEndereco(cep);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }    
        }
    }
}

