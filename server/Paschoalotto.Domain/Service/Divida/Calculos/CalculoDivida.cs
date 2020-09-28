namespace Paschoalotto.Domain.Service
{
    public abstract class CalculoDivida
    {
        public virtual double CalcularDivida(double ValorOriginal, int DiasAtraso, double Juros)
        {
            return ValorOriginal * (1.00 + ((Juros / (double)100) * (double)DiasAtraso));
        }
    }
}
