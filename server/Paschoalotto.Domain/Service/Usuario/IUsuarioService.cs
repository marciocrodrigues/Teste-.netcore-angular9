using Paschoalotto.Domain.DTO;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Service
{
    public interface IUsuarioService : IService<UsuarioDTO>
    {
        Task<IRetorno> BuscarPorDocumentoESenhaAsync(string documento, string senha);
    }
}
