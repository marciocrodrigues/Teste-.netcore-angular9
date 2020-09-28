namespace Paschoalotto.Domain.Entities
{
    public class Parametrizacao : Entity
    {
        public Parametrizacao(int maximoParcelas, string tipoJuros, double porcertagemJuros, double porcentagemComissao)
        {
            MaximoParcelas = maximoParcelas;
            TipoJuros = tipoJuros;
            PorcertagemJuros = porcertagemJuros;
            PorcentagemComissao = porcentagemComissao;
        }

        public int MaximoParcelas { get; private set; }
        public string TipoJuros { get; private set; }
        public double PorcertagemJuros { get; private set; }
        public double PorcentagemComissao { get; set; }

        public void AlterarMaximoParcelas(int valor)
        {
            this.MaximoParcelas = valor;
        }

        public void AlterarTipoJuros(string tipo)
        {
            this.TipoJuros = tipo;
        }

        public void AlterarPorcetagemJuros(double porcentagem)
        {
            this.PorcertagemJuros = porcentagem;
        }

        public void AlterarPorcentagemComissao(double porcentagem)
        {
            this.PorcentagemComissao = porcentagem;
        }
    }
}
