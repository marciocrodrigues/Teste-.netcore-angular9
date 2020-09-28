using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Domain.DTO.Usuario
{
    public class SessaoDTO : Notifiable, IBaseDTO
    {
        public SessaoDTO(){}

        public SessaoDTO(string documento, string senha)
        {
            Documento = documento;
            Senha = senha;
        }

        /// <summary>
        /// Codigo gerador ao cadastraro o usuário(colaborador)
        /// </summary>
        public string Documento { get; set; }
        /// <summary>
        /// Senha cadastrada ao incluir o usuário
        /// </summary>
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Documento, "Codigo", "Preencha o codigo do usuário")
                .HasMaxLen(Documento, 14, "Codigo", "O codigo só pode conter no maximo 10 caracteres")
                .IsNotNullOrEmpty(Senha, "Senha", "Preencha a senha do usuário")
                .HasMaxLen(Senha, 10, "Senha", "A senha só pode conter no maximo 10 caracteres"));
        }
    }
}
