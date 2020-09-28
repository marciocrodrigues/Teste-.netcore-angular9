using Paschoalotto.Domain.DTO;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Service
{
    public interface IService<T> where T : class
    {
        Task<IRetorno> CriarAsync(T dto);
        Task<IRetorno> AlterarAsync(Guid id, T dto);
        Task<IRetorno> ExcluirAsync(Guid id);
        Task<IRetorno> ListarTodosAsync();
        Task<IRetorno> BuscarPorIdAsync(Guid id);
    }
}
