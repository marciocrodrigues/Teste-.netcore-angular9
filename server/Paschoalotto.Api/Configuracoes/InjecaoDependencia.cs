using Microsoft.Extensions.DependencyInjection;
using Paschoalotto.Domain;
using Paschoalotto.Domain.Repository;
using Paschoalotto.Domain.Service;
using Paschoalotto.Infra.Repository;

namespace Paschoalotto.Api.Configuracoes
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection ResolverDependecias(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IParametrizacaoRepository, ParametrizacaoRepository>();
            services.AddScoped<IParametrizacaoService, ParametrizaoService>();
            services.AddScoped<IDividaRepository, DividaRepository>();
            services.AddScoped<IDividaService, DividaService>();

            return services;
        }
    }
}
