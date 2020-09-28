using Paschoalotto.Domain.Repository;
using Paschoalotto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Paschoalotto.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Paschoalotto.Infra.Repository
{
    public class ParametrizacaoRepository : IParametrizacaoRepository
    {
        private readonly DataContext _context;
        public ParametrizacaoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AlterarParametrizacaoAsync(Parametrizacao entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Parametrizacao> BuscarParametrizacaoAsync()
        {
            return await _context.Parametrizacoes.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> InserirParametrizacaoAsync(Parametrizacao entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
