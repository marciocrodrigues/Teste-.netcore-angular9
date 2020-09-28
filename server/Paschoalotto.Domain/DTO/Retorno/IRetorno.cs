namespace Paschoalotto.Domain.DTO
{
    public interface IRetorno
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object ObjRetorno { get; set; }
    }
}
