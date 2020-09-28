using Paschoalotto.Domain;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Tests.Fakes
{
    public class FakeDividaRepository : IDividaRepository
    {
        private List<Divida> listaDividas;
        private Usuario _usuario;
        public FakeDividaRepository()
        {
            listaDividas = new List<Divida>();
            _usuario = new Usuario("123456", "12345678909", "Admin", "14999999999");
        }
        public async Task<bool> AlterarAsync(Divida entity)
        {
            var index = listaDividas.FindIndex(x => x.Id == entity.Id);
            listaDividas[index] = entity;
            return true;
        }

        public async Task<IEnumerable<Divida>> BuscarDividasPorDevedorAsync(string documento)
        {
            return await Task.FromResult(listaDividas.Where(x => x.DocumentoDevedor == documento).ToList());
        }

        public async Task<IEnumerable<Divida>> BuscarDividasPorUsuario(Guid id)
        {
            return await Task.FromResult(listaDividas.Where(x => x.Usuario.Id == id).ToList());
        }

        public async Task<Divida> BuscarPorIdAsync(Guid id)
        {
            return await Task.FromResult(listaDividas.Where(x => x.Id == id).FirstOrDefault());
        }

        public async Task<bool> CriarAsync(Divida entity)
        {
            var count = listaDividas.Count;
            entity.Usuario = _usuario;
            listaDividas.Add(entity);
            return await Task.FromResult(listaDividas.Count > count);
        }

        public async Task<bool> ExcluirAsync(Divida entity)
        {
            var count = listaDividas.Count;
            listaDividas.Remove(entity);
            return await Task.FromResult(listaDividas.Count < count);
        }

        public async Task<IEnumerable<Divida>> ListarTodosAsync()
        {
            return await Task.FromResult(listaDividas);
        }
    }
}
