using Paschoalotto.Domain;
using Paschoalotto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paschoalotto.Tests.Fakes
{
    public class FakeUsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> listaUsuarios;

        public FakeUsuarioRepository()
        {
            listaUsuarios = new List<Usuario>();
        }

        public async Task<bool> AlterarAsync(Usuario entity)
        {
            var index = listaUsuarios.FindIndex(x => x.Id == entity.Id);
            listaUsuarios[index] = entity;
            return await Task.FromResult(true);
        }

        public async Task<Usuario> BuscarPorDocumentoESenhaAsync(string documento, string senha)
        {
            return await Task.FromResult(listaUsuarios.Where(x => x.Documento == documento && x.Senha == senha).FirstOrDefault());
        }

        public async Task<Usuario> BuscarPorIdAsync(Guid id)
        {
            return await Task.FromResult(listaUsuarios.Where(x => x.Id == id).FirstOrDefault());
        }

        public async Task<bool> CriarAsync(Usuario entity)
        {
            var count = listaUsuarios.Count;

            listaUsuarios.Add(entity);

            return await Task.FromResult(listaUsuarios.Count > count);
        }

        public async Task<bool> ExcluirAsync(Usuario entity)
        {
            var count = listaUsuarios.Count;

            listaUsuarios.Remove(entity);

            return await Task.FromResult(listaUsuarios.Count < count);
        }

        public async Task<IEnumerable<Usuario>> ListarTodosAsync()
        {
            return await Task.FromResult(listaUsuarios);
        }
    }
}
