using Microsoft.EntityFrameworkCore;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Repository;
using Paschoalotto.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Infra.Repository
{
    public class DividaRepository : IDividaRepository
    {
        private readonly DataContext _context;
        public DividaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AlterarAsync(Divida entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Divida>> BuscarDividasPorDevedorAsync(string documento)
        {
            return await _context.Dividas.Include(x => x.Usuario).AsNoTracking().Where(x => x.DocumentoDevedor == documento).ToListAsync();
        }

        public async Task<IEnumerable<Divida>> BuscarDividasPorUsuario(Guid id)
        {
            return await _context.Dividas.Include(x => x.Usuario).AsNoTracking().Where(x => x.UsuarioId == id).ToListAsync();
        }

        public async Task<Divida> BuscarPorIdAsync(Guid id)
        {
            return await _context.Dividas.Include(x => x.Usuario).AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> CriarAsync(Divida entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExcluirAsync(Divida entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Divida>> ListarTodosAsync()
        {
            return await _context.Dividas.Include(x => x.Usuario).AsNoTracking().ToListAsync();
        }
    }
}
