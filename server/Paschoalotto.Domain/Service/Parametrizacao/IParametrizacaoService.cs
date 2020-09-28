using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.DTO.Parametrizacao;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Service
{
    public interface IParametrizacaoService
    {
        Task<IRetorno> AlterarParametrizacaoAsync(Guid? id, ParametrizacaoDTO dto);
        Task<IRetorno> BuscarParametrizacaoAsync();
    }
}
