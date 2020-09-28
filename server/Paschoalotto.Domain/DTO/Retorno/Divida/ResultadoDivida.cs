using System;
using System.Collections.Generic;

namespace Paschoalotto.Domain.DTO.Retorno
{
    public class ResultadoDivida
    {
        public ResultadoDivida(DateTime dataVencimento, int numeroParcelas, int diasAtraso, double valorOriginal, double valorJuros, double valorFinal, string telefoneColaborador, IEnumerable<Parcela> parcelas)
        {
            DataVencimento = dataVencimento;
            NumeroParcelas = numeroParcelas;
            DiasAtraso = diasAtraso;
            ValorOriginal = valorOriginal;
            ValorJuros = valorJuros;
            ValorFinal = valorFinal;
            TelefoneColaborador = telefoneColaborador;
            Parcelas = parcelas;
        }

        public DateTime DataVencimento { get; private set; }
        public int NumeroParcelas { get; private set; }
        public int DiasAtraso { get; private set; }
        public double ValorOriginal { get; private set; }
        public double ValorJuros { get; private set; }
        public double ValorFinal { get; private set; }
        public string TelefoneColaborador { get; private set; }
        public IEnumerable<Parcela> Parcelas { get; private set; }
    }
}
