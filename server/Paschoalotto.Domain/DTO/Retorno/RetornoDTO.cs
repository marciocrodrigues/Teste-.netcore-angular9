namespace Paschoalotto.Domain.DTO
{
    public class RetornoDTO : IRetorno
    {
        public RetornoDTO(bool sucesso, string mensagem, object objRetorno)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            ObjRetorno = objRetorno;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object ObjRetorno { get; set; }

    }
}
