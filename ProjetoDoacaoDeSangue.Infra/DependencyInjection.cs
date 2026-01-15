using Microsoft.Extensions.DependencyInjection;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IDoadorRepository, DoadorRepository>();

            return services;
        }
    }
}
