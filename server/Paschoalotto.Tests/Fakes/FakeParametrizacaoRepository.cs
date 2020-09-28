using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Tests.Fakes
{
    public class FakeParametrizacaoRepository : IParametrizacaoRepository
    {
        private List<Parametrizacao> listaParametrizacao;

        public FakeParametrizacaoRepository()
        {
            listaParametrizacao = new List<Parametrizacao>();
        }
        
        public async Task<bool> AlterarParametrizacaoAsync(Parametrizacao entity)
        {
           var index = listaParametrizacao.FindIndex(x => x.Id == entity.Id);
           listaParametrizacao[index] = entity;
           return await Task.FromResult(true);
        }

        public  async Task<Parametrizacao> BuscarParametrizacaoAsync()
        {
            return await Task.FromResult(listaParametrizacao.FirstOrDefault());
        }

        public async Task<bool> InserirParametrizacaoAsync(Parametrizacao entity)
        {
            listaParametrizacao.Add(entity);
            return await Task.FromResult(listaParametrizacao.Count > 0 && listaParametrizacao.Count == 1);
        }
    }
}
