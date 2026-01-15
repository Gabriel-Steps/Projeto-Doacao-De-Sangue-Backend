using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories
{
    public interface IDoadorRepository
    {
        public Task<List<Doador>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Doador?> GetById(int id, CancellationToken cancellationToken);
        public Task<List<Doacao>> GetDonationHistory(int id, CancellationToken cancellationToken);
        public Task<Doador?> GetByEmail(string email, CancellationToken cancellationToken);
        public Task CreateAsync(Doador model, CancellationToken cancellationToken);
        public Task Delete(Doador model, CancellationToken cancellationToken);
        public Task Update(Doador model, CancellationToken cancellationToken);
    }
}
