using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paschoalotto.Domain
{
    public interface IRepository<T> where T : class
    {
        Task<bool> CriarAsync(T entity);
        Task<bool> AlterarAsync(T entity);
        Task<bool> ExcluirAsync(T entity);
        Task<T> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<T>> ListarTodosAsync();
    }
}
