using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.DTO.Retorno;
using Paschoalotto.Domain.Entities;
using Paschoalotto.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Service
{
    public class DividaService : IDividaService
    {
        private readonly IDividaRepository _repository;
        private readonly IParametrizacaoRepository _parametrizacaoRepository;

        public DividaService(IDividaRepository repository,
                             IParametrizacaoRepository parametrizacaoRepository)
        {
            _repository = repository;
            _parametrizacaoRepository = parametrizacaoRepository;
        }

        public async Task<IRetorno> ExluirDivida(Guid id)
        {
            try
            {
                var divida = await _repository.BuscarPorIdAsync(id);

                if (divida == null)
                    return new RetornoDTO(false, "Divida não encontrada", null);

                var exclusaoDivida = await _repository.ExcluirAsync(divida);

                if (exclusaoDivida)
                    return new RetornoDTO(true, "Divida excluida com sucesso", null);

                return new RetornoDTO(false, "Erro ao tentar excluir divida da base de dados", null);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IRetorno> IncluirDivida(DividaDTO dto)
        {
            try
            {
                dto.Validate();

                if (dto.Invalid)
                    return new RetornoDTO(false, "Erro na requisição, verificar parametros de entrar", dto.Notifications);

                var divida = new Divida(dto.ValorOriginal, dto.DataVencimento, dto.DocumentoDevedor, dto.UsuarioId);

                var dividaCriada = await _repository.CriarAsync(divida);

                if (dividaCriada)
                    return new RetornoDTO(true, "Divida incluida com sucesso", divida);

                return new RetornoDTO(false, "Erro ao tentar salvar os dados na base", null);
            }catch(Exception ex)
            {
                throw ex;
            }


        }

        public async Task<RetornoDivida> ListarDivida(string DocumentoDevedor)
        {
            try
            {
                var parametrizacao = await BuscarParametrizacao();
                var retornoDividas = await _repository.BuscarDividasPorDevedorAsync(DocumentoDevedor);
                var listaResultadoDivida = new List<ResultadoDivida>();

                foreach (var item in retornoDividas)
                {
                    var resultadoDivida = CalcularResultadoDivida(item, parametrizacao);
                    listaResultadoDivida.Add(resultadoDivida);
                }

                return new RetornoDivida(true, "", listaResultadoDivida);
            } catch(Exception ex)
            {
                throw ex;
            }

        }

        
        public async Task<RetornoDivida> ListarDividasPorUsuario(Guid id)
        {
            try
            {
                var parametrizacao = await BuscarParametrizacao();
                var retornoDividas = await _repository.BuscarDividasPorUsuario(id);
                var listaResultadoDivida = new List<ResultadoDivida>();

                foreach (var item in retornoDividas)
                {
                    var resultadoDivida = CalcularResultadoDivida(item, parametrizacao);
                    listaResultadoDivida.Add(resultadoDivida);
                }

                return new RetornoDivida(true, "", listaResultadoDivida);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Parametrizacao> BuscarParametrizacao()
        {
            try
            {
                var parametrizacao = await _parametrizacaoRepository.BuscarParametrizacaoAsync();

                return parametrizacao;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private ResultadoDivida CalcularResultadoDivida(Divida divida, Parametrizacao parametrizacao)
        {
            try
            {
                var totalAPagar = CalCularValorTotalAPagar(divida, parametrizacao);
                var diasAtraso = DateTime.Now.Subtract(divida.DataVencimento).Days;

                var listaParcela = CalcularParcelas(parametrizacao, divida);

                return new ResultadoDivida(divida.DataVencimento, parametrizacao.MaximoParcelas, diasAtraso, divida.ValorOriginal, totalAPagar - divida.ValorOriginal, totalAPagar, divida.Usuario.Telefone, listaParcela);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private List<Parcela> CalcularParcelas(Parametrizacao parametrizacao, Divida divida)
        {
            try
            {
                var listaParcela = new List<Parcela>();
                var totalAPagar = CalCularValorTotalAPagar(divida, parametrizacao);
                var valorParcela = totalAPagar / parametrizacao.MaximoParcelas;
                var diaVencimento = DateTime.Now.AddDays(1).Day;
                var anoVencimento = DateTime.Now.Year;
                var mesVencimeto = DateTime.Now.Month;

                for (int i = 0; i < parametrizacao.MaximoParcelas; i++)
                {
                    var numeroParcela = i + 1;

                    var parcela = new Parcela(numeroParcela, valorParcela, new DateTime(anoVencimento, mesVencimeto + (i + 1), diaVencimento));
                    listaParcela.Add(parcela);
                }

                return listaParcela;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        private double CalCularValorTotalAPagar(Divida divida, Parametrizacao parametrizacao)
        {
            try
            {
                var diasAtraso = DateTime.Now.Subtract(divida.DataVencimento).Days;

                if (parametrizacao.TipoJuros.Equals("S"))
                {
                    var calculoJurosSimples = new CalculoDividaJurosSimples();
                    return calculoJurosSimples.CalcularDivida(divida.ValorOriginal, diasAtraso, parametrizacao.PorcertagemJuros);
                }
                else
                {
                    var calculoJurosComposto = new CalculoDividaJurosComposto();
                    return calculoJurosComposto.CalcularDivida(divida.ValorOriginal, diasAtraso, parametrizacao.PorcertagemJuros);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
