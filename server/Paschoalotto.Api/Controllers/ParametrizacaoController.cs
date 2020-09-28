using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Domain.DTO.Parametrizacao;
using Paschoalotto.Domain.Service;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ParametrizacaoController : ControllerBase
    {
        private readonly IParametrizacaoService _service;

        public ParametrizacaoController(IParametrizacaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Criar uma parametrização
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Route("criar-parametrizacao")]
        [HttpPost]
        public async Task<IActionResult> CriarParametrizacao([FromBody] ParametrizacaoDTO dto)
        {
            var retorno = await _service.AlterarParametrizacaoAsync(null, dto);

            if (retorno.Sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }

        /// <summary>
        /// Alterar valores da parametrização
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Route("{id:Guid}/alterar-parametrizacao")]
        [HttpPut]
        public async Task<IActionResult> AlterarParametrizacao(Guid id, [FromBody] ParametrizacaoDTO dto)
        {
            var retorno = await _service.AlterarParametrizacaoAsync(id, dto);

            if (retorno.Sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }

        /// <summary>
        /// Buscar parametrização
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Route("buscar-parametrizacao")]
        [HttpGet]
        public async Task<IActionResult> BuscarParametrizacoes()
        {
            var retorno = await _service.BuscarParametrizacaoAsync();

            return Ok(retorno);
        }
    }
}
