using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Api.Configuracoes;
using Paschoalotto.Domain.DTO.Usuario;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Service;

namespace Paschoalotto.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public SessaoController(IUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gerar token para autenticação
        /// </summary>
        /// <param name="dto"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Erro interno do servidor</response>
        [Route("gerar-token")]
        [HttpPost]
        public async Task<IActionResult> BuscarUsuarioPorCodigoESenha([FromBody]SessaoDTO dto)
        {
            try
            {
                var retorno = await _service.BuscarPorDocumentoESenhaAsync(dto.Documento, dto.Senha);

                if (!retorno.Sucesso)
                    return BadRequest(retorno);

                var usuario = (Usuario)retorno.ObjRetorno;
                var token = Token.GerarToken(usuario);

                return Ok(new { usuario.Id, usuario.Codigo, usuario.Nome, token });

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Mensagem = "Erro Interno do Servidor, entre em contato com o administrador" });
            }
        }
    }
}
