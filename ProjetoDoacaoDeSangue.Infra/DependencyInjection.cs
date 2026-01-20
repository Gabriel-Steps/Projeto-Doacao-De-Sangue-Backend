using Microsoft.Extensions.DependencyInjection;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoacaoRepositories;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;
using ProjetoDoacaoDeSangue.Infra.Repositories.EstoqueDeSangueRepositories;

namespace ProjetoDoacaoDeSangue.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IDoadorRepository, DoadorRepository>();
            services.AddScoped<IDoacaoRepository, DoacaoRepository>();
            services.AddScoped<IEstoqueDeSangueRepository, EstoqueDeSangueRepository>();

            return services;
        }
    }
}
