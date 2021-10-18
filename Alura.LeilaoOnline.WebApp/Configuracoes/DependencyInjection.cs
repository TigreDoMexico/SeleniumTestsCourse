using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Contratos;
using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.LeilaoOnline.WebApp.Configuracoes
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseDependency(this IServiceCollection services, IConfiguration configuration)
        {
            var cnxString = configuration.GetConnectionString("LeiloesDB");
            services.AddDbContext<LeiloesContext>(options =>
            {
                options.UseSqlServer(cnxString);
            });

            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IModalidadeAvaliacao, MaiorValor>();
            services.AddTransient<IRepositorio<Leilao>, RepositorioLeilao>();
            services.AddTransient<IRepositorio<Interessada>, RepositorioInteressada>();
            services.AddTransient<IRepositorio<Usuario>, RepositorioUsuario>();

            return services;
        }
    }
}
