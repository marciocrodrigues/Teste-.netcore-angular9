using Paschoalotto.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Paschoalotto.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(string senha, string documento, string nome, string telefone)
        {
            Codigo = Guid.NewGuid().ToString().Replace("-", "").Replace(".", "").Substring(0, 10);
            Senha = senha;
            Documento = documento;
            Nome = nome;
            Telefone = telefone;
        }

        public string Codigo { get; private set; }
        public string Senha { get; private set; }
        public string Documento { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public virtual IEnumerable<Divida> Dividas { get; private set;}

        public void AlterarSenha(string senha)
        {
            this.Senha = senha;
        }

        public void AlterarDocumento(string documento)
        {
            this.Documento = documento;
        }

        public void AlterarNome(string nome)
        {
            this.Nome = nome;
        }

        public void AlterarTelefone(string telefone)
        {
            this.Telefone = telefone;
        }

    }
}
