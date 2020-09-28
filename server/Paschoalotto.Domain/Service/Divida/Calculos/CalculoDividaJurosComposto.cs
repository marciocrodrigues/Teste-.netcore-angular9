using System;

namespace Paschoalotto.Domain.Service
{
    public class CalculoDividaJurosComposto : CalculoDivida
    {
        public override double CalcularDivida(double ValorOriginal, int DiasAtraso, double Juros)
        {
            Juros = (1 + (Juros / 100));

            return ValorOriginal * (Math.Pow(Juros, DiasAtraso));
        }
    }
}
