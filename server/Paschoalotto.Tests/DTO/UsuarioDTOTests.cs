using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paschoalotto.Domain.DTO;

namespace Paschoalotto.Tests.DTO
{
    [TestClass]
    public class UsuarioDTOTests
    {
        private UsuarioDTO _usuarioValido;
        private UsuarioDTO _usuarioInvalido;

        public UsuarioDTOTests()
        {
            _usuarioValido = new UsuarioDTO("123456", "12345678909", "teste da silva", "14999999999");
            _usuarioInvalido = new UsuarioDTO("", "", "", "");
        }

        [TestMethod]
        public void Inserindo_Valores_Incorretos_Para_UsuarioDTO()
        {
            _usuarioInvalido.Validate();
            Assert.AreEqual(true, _usuarioInvalido.Invalid);
        }

        [TestMethod]
        public void Inserindo_Valores_Corretos_Para_UsuarioDTO()
        {
            _usuarioValido.Validate();
            Assert.AreEqual(false, _usuarioValido.Invalid);
        }
    }
}
