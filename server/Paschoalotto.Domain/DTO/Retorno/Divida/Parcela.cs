using System;

namespace Paschoalotto.Domain.DTO.Retorno
{
    public class Parcela
    {
        public Parcela(int numeroParcela, double valorParcela, DateTime dataVencimento)
        {
            NumeroParcela = numeroParcela;
            ValorParcela = valorParcela;
            DataVencimento = dataVencimento;
        }

        public int NumeroParcela { get; private set; }
        public double ValorParcela { get; private set; }
        public DateTime DataVencimento { get; private set; }
    }
}
