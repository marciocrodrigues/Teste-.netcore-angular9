using Paschoalotto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Repository
{
    public interface IDividaRepository : IRepository<Divida>
    {
        Task<IEnumerable<Divida>> BuscarDividasPorDevedorAsync(string documento);
        Task<IEnumerable<Divida>> BuscarDividasPorUsuario(Guid id);
    }
}
