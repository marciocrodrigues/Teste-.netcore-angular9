using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.Service;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Listar usuários(colaboradores)
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Authorize]
        [Route("listar-usuarios")]
        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var retorno = await _service.ListarTodosAsync();

            return Ok(retorno);
        }

        /// <summary>
        /// Incluir um novo usuário(colaborador)
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Erro interno do servidor</response>
        [AllowAnonymous]
        [Route("criar-usuario")]
        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioDTO dto)
        {
            var retorno = await _service.CriarAsync(dto);

            if (retorno.Sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }

        /// <summary>
        /// Alterar os de um usuário(colaborador)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Authorize]
        [Route("{id:Guid}/alterar-usuario")]
        [HttpPut]
        public async Task<IActionResult> AlterarUsuario(Guid id, [FromBody] UsuarioDTO dto)
        {
            var retorno = await _service.AlterarAsync(id, dto);

            if (retorno.Sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }

        /// <summary>
        /// Buscar usuário(colaborador) pelo seu identificador
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Authorize]
        [Route("{id:Guid}/buscar-usuario")]
        [HttpGet]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var retorno = await _service.BuscarPorIdAsync(id);

            return Ok(retorno);
        }

        /// <summary>
        /// Excluir um usuário(colaborador)
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Requisição não autorizada</response>
        /// <response code="500">Erro interno do servidor</response>
        [Authorize]
        [Route("{id:Guid}/excluir-usuario")]
        [HttpDelete]
        public async Task<IActionResult> ExcluirUsuario(Guid id)
        {
            var retorno = await _service.ExcluirAsync(id);

            if (retorno.Sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }
    }
}
