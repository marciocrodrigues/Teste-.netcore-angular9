using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paschoalotto.Domain.DTO.Parametrizacao;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Service;
using Paschoalotto.Tests.Fakes;
using System.Threading.Tasks;

namespace Paschoalotto.Tests.Service
{
    [TestClass]
    public class ParametrizacaoServiceTests
    {
        private ParametrizacaoDTO _parametrizacaoValida;
        private ParametrizacaoDTO _parametrizacaoInvalida;
        private FakeParametrizacaoRepository _repository;
        private ParametrizaoService _service;

        public ParametrizacaoServiceTests()
        {
            _repository = new FakeParametrizacaoRepository();
            _service = new ParametrizaoService(_repository);
            _parametrizacaoValida = new ParametrizacaoDTO(3, "S", 0.2, 10);
            _parametrizacaoInvalida = new ParametrizacaoDTO(0, "", 0, 0);
        }

        [TestMethod]
        public async Task Nao_Pode_Ser_Inserido_Parametrizacao_Com_Valores_Vazios_Ou_Zeros()
        {
            var parametrizacaoCriada = await _service.AlterarParametrizacaoAsync(null, _parametrizacaoInvalida);
            Assert.AreEqual(false, parametrizacaoCriada.Sucesso);
        }

        [TestMethod]
        public async Task Deve_Poder_Criar_Parametrizacao_Quando_Passado_Valores_Corretos()
        {
            var parametrizacaoCriada = await _service.AlterarParametrizacaoAsync(null, _parametrizacaoValida);
            Assert.AreEqual(true, parametrizacaoCriada.Sucesso);
        }

        [TestMethod]
        public async Task Deve_Alterar_Parametrizacao_Caso_Ja_Exista_Uma()
        {
            var parametrizacaoCriada = await _service.AlterarParametrizacaoAsync(null, _parametrizacaoValida);
            var parametrizacao = (Parametrizacao)parametrizacaoCriada.ObjRetorno;
            var id = parametrizacao.Id;
            var maximoParcelas = parametrizacao.MaximoParcelas;

            var dto = new ParametrizacaoDTO(10, "S", 0.2, 10);

            var parametrizacaoAlterada = await _service.AlterarParametrizacaoAsync(id, dto);

            Assert.AreEqual(true, parametrizacaoAlterada.Sucesso && (((Parametrizacao)parametrizacaoAlterada.ObjRetorno).Id == id && ((Parametrizacao)parametrizacaoAlterada.ObjRetorno).MaximoParcelas != maximoParcelas));


        }
    }
}
