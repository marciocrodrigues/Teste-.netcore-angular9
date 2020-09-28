using Paschoalotto.Domain.DTO;
using Paschoalotto.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Paschoalotto.Domain.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IRetorno> AlterarAsync(Guid id, UsuarioDTO dto)
        {
            try
            {
                dto.Validate();

                if (dto.Invalid)
                {
                    return new RetornoDTO(false, "Erro na requisição, verificar parametros de entrar", dto.Notifications);
                }

                var usuario = await _repository.BuscarPorIdAsync(id);
                usuario.AlterarNome(dto.Nome);
                usuario.AlterarDocumento(dto.Documento);
                usuario.AlterarSenha(dto.Senha);

                var usuarioAlterado = await _repository.AlterarAsync(usuario);

                if (usuarioAlterado)
                {
                    return new RetornoDTO(true, "Usuário alterador com sucesso", usuario);
                }

                return new RetornoDTO(false, "Erro ao tentar salvar alteração na base", null);
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IRetorno> BuscarPorIdAsync(Guid id)
        {
            try
            {
                var usuario = await _repository.BuscarPorIdAsync(id);

                if (usuario == null)
                {
                    return new RetornoDTO(false, "Usuário não encontrado", null);
                }

                return new RetornoDTO(true, "", usuario);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IRetorno> BuscarPorDocumentoESenhaAsync(string documento, string senha)
        {
            try
            {
                var usuario = await _repository.BuscarPorDocumentoESenhaAsync(documento, senha);

                if (usuario == null)
                {
                    return new RetornoDTO(false, "Nenhum usuário corresponde ao codigo e sneha informados", null);
                }

                return new RetornoDTO(true, "", usuario);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IRetorno> CriarAsync(UsuarioDTO dto)
        {
            try
            {
                dto.Validate();

                if (dto.Invalid)
                {
                    return new RetornoDTO(false, "Erro na requisição, verificar parametros de entrar", dto.Notifications);
                }

                var usuario = new Usuario(dto.Senha, dto.Documento, dto.Nome, dto.Telefone);

                var usuarioCriado = await _repository.CriarAsync(usuario);

                if (usuarioCriado)
                {
                    return new RetornoDTO(true, "Usuário criado com suceso", usuario);
                }

                return new RetornoDTO(false, "Erro ao tentar incluir na base", null);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IRetorno> ExcluirAsync(Guid id)
        {
            try
            {
                var usuario = await _repository.BuscarPorIdAsync(id);

                if (usuario == null)
                {
                    return new RetornoDTO(false, "Usuário não encontrado", null);
                }

                var usuarioExcluido = await _repository.ExcluirAsync(usuario);

                if (usuarioExcluido)
                {
                    return new RetornoDTO(true, "Usuário excluido com sucesso", null);
                }

                return new RetornoDTO(false, "Erro ao tentar excluir usuário da base", null);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IRetorno> ListarTodosAsync()
        {
            try
            {
                var usuarios = await _repository.ListarTodosAsync();

                return new RetornoDTO(true, "", usuarios);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
