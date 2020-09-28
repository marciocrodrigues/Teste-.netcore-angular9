using Paschoalotto.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Repository
{
    public interface IParametrizacaoRepository
    {
        Task<bool> AlterarParametrizacaoAsync(Parametrizacao entity);

        Task<Parametrizacao> BuscarParametrizacaoAsync();

        Task<bool> InserirParametrizacaoAsync(Parametrizacao entity);
    }
}
