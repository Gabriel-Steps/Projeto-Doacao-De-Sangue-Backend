using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Core.Enums;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.EstoqueDeSangueRepositories
{
    public interface IEstoqueDeSangueRepository
    {
        public Task CreateAsync(EstoqueSangue model, CancellationToken cancellationToken);
        public Task UpdateAsync(EstoqueSangue model, CancellationToken cancellationToken);
        public Task<EstoqueSangue?> GetByTypeBloodAsync(TiposSanguineos tipo,  CancellationToken cancellationToken);
        public Task<List<EstoqueSangue>> GetAllAsync(CancellationToken cancellationToken);
    }
}
