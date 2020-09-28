using System;

namespace Paschoalotto.Domain.Entities
{
    public class Divida : Entity
    {
        public Divida(double valorOriginal, DateTime dataVencimento, string documentoDevedor, Guid usuarioId)
        {
            ValorOriginal = valorOriginal;
            DataVencimento = dataVencimento;
            DocumentoDevedor = documentoDevedor;
            UsuarioId = usuarioId;
        }

        public double ValorOriginal { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public string DocumentoDevedor { get; private set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
