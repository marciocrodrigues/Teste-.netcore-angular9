using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.DTO.Retorno;
using Paschoalotto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Service
{
    public interface IDividaService
    {
        Task<IRetorno> IncluirDivida(DividaDTO dto);

        Task<RetornoDivida> ListarDivida(string DocumentoDevedor);

        Task<RetornoDivida> ListarDividasPorUsuario(Guid id);
        Task<IRetorno> ExluirDivida(Guid id);
    }
}
