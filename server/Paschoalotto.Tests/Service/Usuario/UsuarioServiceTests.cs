using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paschoalotto.Domain;
using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Service;
using Paschoalotto.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Tests.Service
{
    [TestClass]
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _service;
        private readonly FakeUsuarioRepository _fakeRepository;
        private UsuarioDTO _usuarioDTO;
        private UsuarioDTO _usuarioDTO2;
        private UsuarioDTO _usuarioDTO3;

        public UsuarioServiceTests()
        {
            _fakeRepository = new FakeUsuarioRepository();
            _service = new UsuarioService(_fakeRepository);
            _usuarioDTO = new UsuarioDTO("123456", "1234567809", "usuario teste", "14999999999");
            _usuarioDTO2 = new UsuarioDTO("123456", "1234567810", "usuario teste2", "14999999999");
            _usuarioDTO3 = new UsuarioDTO("123456", "1234567811", "usuario teste3", "14999999999");
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Criar_Um_Usuario()
        {
            var usuarioCriado = await _service.CriarAsync(_usuarioDTO);
            Assert.AreEqual(true, usuarioCriado.Sucesso);
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Alterar_Um_Usuario()
        {
            var retorno = await _service.CriarAsync(_usuarioDTO);
            var usuario = (Usuario)retorno.ObjRetorno;
            Guid id = usuario.Id;
            var nome = usuario.Nome;
            var usuarioDTO = new UsuarioDTO("123456", "1234567809", "usuario teste da silva", "14999999999");

            await _service.AlterarAsync(id, usuarioDTO);

            Assert.AreEqual(true, usuario.Id == id && usuario.Nome != nome);
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Excluir_Um_Usuario()
        {
            var retorno = await _service.CriarAsync(_usuarioDTO);

            Guid id = ((Usuario)retorno.ObjRetorno).Id;


            var usuarioExcluido = await _service.ExcluirAsync(id);

            Assert.AreEqual(true, usuarioExcluido.Sucesso);
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Busca_Usuario_Por_Codigo_E_Senha()
        {
            var retorno = await _service.CriarAsync(_usuarioDTO);
            var retorno2 = await _service.CriarAsync(_usuarioDTO2);

            var documento = ((Usuario)retorno.ObjRetorno).Documento;

            var buscarPorCodESenha = await _service.BuscarPorDocumentoESenhaAsync(documento, "123456");

            Assert.AreEqual(true, buscarPorCodESenha.Sucesso);
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Buscar_Usuario_Por_Id()
        {
            var retorno = await _service.CriarAsync(_usuarioDTO);
            var retorno2 = await _service.CriarAsync(_usuarioDTO2);

            var id = ((Usuario)retorno.ObjRetorno).Id;

            var buscarPorId = await _service.BuscarPorIdAsync(id);

            Assert.AreEqual(true, buscarPorId.Sucesso);
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Listar_Usuarios()
        {
            var retorno = await _service.CriarAsync(_usuarioDTO);
            var retorno2 = await _service.CriarAsync(_usuarioDTO2);
            var retorno3 = await _service.CriarAsync(_usuarioDTO3);

            var listaUsuarios = await _service.ListarTodosAsync();

            Assert.AreEqual(3, ((IEnumerable<Usuario>)listaUsuarios.ObjRetorno).Count());
        }
    }
}
