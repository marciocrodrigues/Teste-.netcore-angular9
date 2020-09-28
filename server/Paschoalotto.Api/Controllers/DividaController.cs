using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.Service;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DividaController : ControllerBase
    {
        private readonly IDividaService _service;
        public DividaController(IDividaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Incluir uma nova divida
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <returns></returns>
        [Authorize]
        [Route("incluir-divida")]
        [HttpPost]
        public async Task<IActionResult> IncluirDivida([FromBody] DividaDTO dto)
        {
            try
            {
                var retorno = await _service.IncluirDivida(dto);

                if (retorno.Sucesso)
                    return Ok(retorno);

                return BadRequest(retorno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = "Erro Interno do Servidor, entre em contato com o administrador" });
            }
        }

        /// <summary>
        /// Listar as dividas de um devedor pelo documento CPF/CNPJ
        /// </summary>
        /// <param name="documento"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Route("{documento}/listar-dividas-devedor")]
        [HttpGet]
        public async Task<IActionResult> ListarDivida(string documento)
        {
            try
            {
                var retorno = await _service.ListarDivida(documento);

                if (retorno.Sucesso)
                    return Ok(retorno);

                return NotFound(retorno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = "Erro Interno do Servidor, entre em contato com o administrador" });
            }
        }

        /// <summary>
        /// Listar as dividas de um usuário por seu identificador
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Authorize]
        [Route("{id:Guid}/listar-dividas")]
        [HttpGet]
        public async Task<IActionResult> ListarDividasPorUsuario(Guid id)
        {
            try
            {
                var retorno = await _service.ListarDividasPorUsuario(id);

                if (retorno.Sucesso)
                    return Ok(retorno);

                return NotFound(retorno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = "Erro Interno do Servidor, entre em contato com o administrador" });
            }
        }

        /// <summary>
        /// Excluir uma divida pelo identifidador
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Authorize]
        [Route("{id:Guid}/exluir-divida")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirDivida(Guid id)
        {
            try
            {
                var retorno = await _service.ExluirDivida(id);

                if (retorno.Sucesso)
                    return Ok(retorno);

                return NotFound(retorno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = "Erro Interno do Servidor, entre em contato com o administrador" });
            }
        }
    }
}
