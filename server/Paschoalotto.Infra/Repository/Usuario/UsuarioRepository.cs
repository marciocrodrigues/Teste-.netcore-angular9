using Microsoft.EntityFrameworkCore;
using Paschoalotto.Domain;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;
        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AlterarAsync(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Usuario> BuscarPorDocumentoESenhaAsync(string documento, string senha)
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Documento == documento && x.Senha == senha).FirstOrDefaultAsync();
        }

        public async Task<Usuario> BuscarPorIdAsync(Guid id)
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Id == id).Include(x => x.Dividas).FirstOrDefaultAsync();
        }

        public async Task<bool> CriarAsync(Usuario entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExcluirAsync(Usuario entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Usuario>> ListarTodosAsync()
        {
            return await _context.Usuarios.AsNoTracking().Include(x => x.Dividas).ToListAsync();
        }
    }
}
