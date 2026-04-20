using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Infra;

namespace Dominio.Infra
{
    public static class ServicesExtensionDomain
    {
        public static void ConfigurarDominio(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigurarRepositorio(configuration);
            
            services.AddScoped<ContasBancariasDomain>();
        }
    }

}