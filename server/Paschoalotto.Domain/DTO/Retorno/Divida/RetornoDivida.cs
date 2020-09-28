using System.Collections.Generic;

namespace Paschoalotto.Domain.DTO.Retorno
{
    public class RetornoDivida
    {
        public RetornoDivida(bool sucesso, string mensagem, IEnumerable<ResultadoDivida> divida)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Divida = divida;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public IEnumerable<ResultadoDivida> Divida { get; private set; }
    }
}
