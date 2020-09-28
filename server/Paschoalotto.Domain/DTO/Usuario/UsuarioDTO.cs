using Flunt.Notifications;
using Flunt.Validations;

namespace Paschoalotto.Domain.DTO
{
    public class UsuarioDTO : Notifiable, IBaseDTO
    {
        public UsuarioDTO(){}

        public UsuarioDTO(string senha, string documento, string nome, string telefone)
        {
            Senha = senha;
            Documento = documento;
            Nome = nome;
            Telefone = telefone;
        }

        /// <summary>
        /// Senha para futuro acesso do colaborador
        /// </summary>
        public string Senha { get; set; }
        /// <summary>
        /// Documento CPF do colaborador
        /// </summary>
        public string Documento { get; set; }
        /// <summary>
        /// Nome inteiro do colaborador
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Telefone de contado do colaborador com DDD
        /// </summary>
        public string Telefone { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Senha, "Senha", "Preencha o Senha")
                .HasMaxLen(Senha, 10, "Senha", "A senha só pode conter no maximo 10 caracteres")
                .IsNotNullOrEmpty(Documento, "Documento", "Preencha o Documento")
                .HasMaxLen(Documento, 14, "Documento", "O documento só pode conter no maximo 14 caracteres")
                .IsNotNullOrEmpty(Nome, "Nome", "Preencha o Nome")
                .HasMaxLen(Nome, 100, "Nome", "O nome só pode conter no maximo 100 caracteres")
                .IsNotNullOrEmpty(Telefone, "Telefone", "Preencha o Telefone")
                .HasMaxLen(Telefone, 11, "Telefone", "O telefone só pode conter no maximo 11 caracteres"));
        }
    }
}
