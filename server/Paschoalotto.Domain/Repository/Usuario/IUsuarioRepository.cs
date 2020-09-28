using Paschoalotto.Domain.Entities;
using System.Threading.Tasks;

namespace Paschoalotto.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> BuscarPorDocumentoESenhaAsync(string documento, string senha);
    }
}
