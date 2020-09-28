using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.DTO.Parametrizacao;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Service
{
    public class ParametrizaoService : IParametrizacaoService
    {
        private readonly IParametrizacaoRepository _repository;

        public ParametrizaoService(IParametrizacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IRetorno> AlterarParametrizacaoAsync(Guid? id, ParametrizacaoDTO dto)
        {
            try
            {
                dto.Validate();

                if (dto.Invalid)
                {
                    return new RetornoDTO(false, "Erro na requisição, verificar parametros de entrar", dto.Notifications);
                }

                if (id != null)
                {
                    var parametrizacao = await _repository.BuscarParametrizacaoAsync();

                    parametrizacao.AlterarMaximoParcelas(dto.MaximoParcelas);
                    parametrizacao.AlterarTipoJuros(dto.TipoJuros);
                    parametrizacao.AlterarPorcetagemJuros(dto.PorcertagemJuros);
                    parametrizacao.AlterarPorcentagemComissao(dto.PorcentagemComissao);

                    var parametrizacaoAlterada = await _repository.AlterarParametrizacaoAsync(parametrizacao);

                    if (parametrizacaoAlterada)
                        return new RetornoDTO(true, "Parametrizacao salva com sucesso", parametrizacao);

                    return new RetornoDTO(false, "Erro ao tentar salvar os dados na base", null);
                }


                var novaParametrizacao = new Parametrizacao(dto.MaximoParcelas, dto.TipoJuros, dto.PorcertagemJuros, dto.PorcentagemComissao);

                var parametrizacaoinserida = await _repository.InserirParametrizacaoAsync(novaParametrizacao);

                if (parametrizacaoinserida)
                    return new RetornoDTO(true, "Parametrizacao salva com sucesso", novaParametrizacao);

                return new RetornoDTO(false, "Erro ao tentar salvar os dados na base", null);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IRetorno> BuscarParametrizacaoAsync()
        {
            try
            {
                var parametrizacao = await _repository.BuscarParametrizacaoAsync();

                return new RetornoDTO(true, "", parametrizacao);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
