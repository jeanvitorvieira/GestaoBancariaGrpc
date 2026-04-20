using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repositorio.Infra
{
    public static class ServicesExtensionRepository
    {
        public static void ConfigurarRepositorio(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sqlite");
            services.AddDbContext<DataContext>(opt => opt.UseSqlite(connectionString));

            services.AddScoped<ContasBancariasRepository>();
        }
    }
}