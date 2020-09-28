using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paschoalotto.Domain;
using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.DTO.Parametrizacao;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Service;
using Paschoalotto.Tests.Fakes;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Tests.Service
{
    [TestClass]
    public class DividaServiceTests
    {
        private UsuarioDTO _usuarioDTO;
        private ParametrizacaoDTO _parametrizacaoDTO;
        private DividaDTO _dividaDTO;
        private readonly FakeUsuarioRepository _usuarioRepository;
        private readonly FakeParametrizacaoRepository _parametrizacaoRepository;
        private readonly FakeDividaRepository _repository;
        private readonly UsuarioService _usuarioService;
        private readonly ParametrizaoService _parametrizacaoService;
        private readonly DividaService _service;

        public DividaServiceTests()
        {
            _usuarioDTO = new UsuarioDTO("123456", "12345678909", "Admin", "14999999999");
            _parametrizacaoDTO = new ParametrizacaoDTO(3, "C", 0.2, 10.0);
            _usuarioRepository = new FakeUsuarioRepository();
            _parametrizacaoRepository = new FakeParametrizacaoRepository();
            _repository = new FakeDividaRepository();
            _usuarioService = new UsuarioService(_usuarioRepository);
            _parametrizacaoService = new ParametrizaoService(_parametrizacaoRepository);
            _service = new DividaService(_repository, _parametrizacaoRepository);
        }

        private async Task<Usuario> CriarUsuario()
        {
            var retorno = await _usuarioService.CriarAsync(_usuarioDTO);
            var usuario = (Usuario)retorno.ObjRetorno;
            return usuario;
        }

        private async Task<Parametrizacao> CriarParametrizacao()
        {
            var retorno = await _parametrizacaoService.AlterarParametrizacaoAsync(null, _parametrizacaoDTO);
            var parametrizacao = (Parametrizacao)retorno.ObjRetorno;
            return parametrizacao;
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Incluir_Divida()
        {
            var usuario = await CriarUsuario();
            _dividaDTO = new DividaDTO(3000.00, new DateTime(2019, 3, 10), "27001802085", usuario.Id);
            var retorno = await _service.IncluirDivida(_dividaDTO);

            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public async Task Que_Seja_Possivel_Listar_Dividas_De_Devedor_Especifico_Por_Documento()
        {
            var usuario = await CriarUsuario();
            var parametrizacao = await CriarParametrizacao();
            _dividaDTO = new DividaDTO(3000.00, new DateTime(2020, 9, 16), "27001802085", usuario.Id);
            var retorno = await _service.IncluirDivida(_dividaDTO);

            var retornoDividas = await _service.ListarDivida("27001802085");

            Assert.AreEqual(true, retornoDividas.Sucesso);
        }
    }
}
