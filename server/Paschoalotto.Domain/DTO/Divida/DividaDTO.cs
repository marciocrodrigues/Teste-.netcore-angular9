using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Paschoalotto.Domain.DTO
{
    public class DividaDTO : Notifiable, IBaseDTO
    {
        public DividaDTO(){}
        public DividaDTO(double valorOriginal, DateTime dataVencimento, string documentoDevedor, Guid usuarioId)
        {
            ValorOriginal = valorOriginal;
            DataVencimento = dataVencimento;
            DocumentoDevedor = documentoDevedor;
            UsuarioId = usuarioId;
        }

		/// <summary>
		/// Valor da divida sem juros
		/// </summary>
        public double ValorOriginal { get; set; }
		/// <summary>
		/// Data de Vencimento da divida
		/// </summary>
        public DateTime DataVencimento { get; set; }
		/// <summary>
		/// Documento CPF/CNPJ do devedor
		/// </summary>
		public string DocumentoDevedor { get; set; }
		/// <summary>
		/// Identificador do usuario que fez a inclusão
		/// </summary>
        public Guid UsuarioId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(ValorOriginal, 0, "ValorOriginal", "O valor da divida deve ser maior que zero")
                .AreEquals(true, DataVencimento < DateTime.Now, "DataVencimento", "Data de vencimento deve ser anterior a data atual")
                .AreEquals(true, ValidarCpfCnpj(DocumentoDevedor), "DocumentoDevedor", "Preecha com um CPF/CNPJ valido")
				.HasMaxLen(DocumentoDevedor, 14, "DocumentoDevedor", "O documento do devedor só pode conter no maximo 14 caracteres")
                .IsNotNullOrEmpty(UsuarioId.ToString(), "UsuarioId", "Preencha o identificador do usuario"));
        }

		private bool ValidarCpfCnpj(string documento)
		{
			if (documento.Length > 11)
				return ValidarCnpj(documento);

			return ValidarCpf(documento);
		}

		private bool ValidarCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}

		private bool ValidarCpf(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}
	}
}
