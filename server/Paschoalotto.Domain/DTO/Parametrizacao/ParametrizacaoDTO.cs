using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Paschoalotto.Domain.DTO.Parametrizacao
{
    public class ParametrizacaoDTO : Notifiable, IBaseDTO
    {
        public ParametrizacaoDTO(){}

        public ParametrizacaoDTO(int maximoParcelas, string tipoJuros, double porcertagemJuros, double porcentagemComissao)
        {
            MaximoParcelas = maximoParcelas;
            TipoJuros = tipoJuros;
            PorcertagemJuros = porcertagemJuros;
            PorcentagemComissao = porcentagemComissao;
        }

        /// <summary>
        /// Número maximo de parcelas usadas na hora de gerar a divida para negociação
        /// </summary>
        public int MaximoParcelas { get; set; }
        /// <summary>
        /// Tipo de juros usado C: Composto S: Simples
        /// </summary>
        public string TipoJuros { get; set; }
        /// <summary>
        /// Porcentagem do juros
        /// </summary>
        public double PorcertagemJuros { get; set; }
        /// <summary>
        /// Porcentagem da comissão da Paschoalloto
        /// </summary>
        public double PorcentagemComissao { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(MaximoParcelas, 0, "MaximoParcelas", "O maximo de parcelas deve ser maior que zero")
                .AreEquals(true, ValidarTipoJuros(TipoJuros), "TipoJuros", "Preencha o tipo de juros com C: Composto ou S: Simples")
                .IsGreaterThan(PorcertagemJuros, 0, "PorcertagemJuros", "Porcentagem do juros deve ser maior que zero")
                .IsGreaterThan(PorcentagemComissao, 0, "PorcentagemComissao", "Porcentagem da comissão deve ser maior que zero"));

        }

        private bool ValidarTipoJuros(string tipoJuros)
        {
            return Array.Exists(new[] { "C", "S" }, (x => string.Equals(x, tipoJuros, StringComparison.InvariantCulture)));
        }
	}
}
