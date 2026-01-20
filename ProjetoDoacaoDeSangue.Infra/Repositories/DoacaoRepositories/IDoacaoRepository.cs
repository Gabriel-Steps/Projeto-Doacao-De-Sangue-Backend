using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.DoacaoRepositories
{
    public interface IDoacaoRepository
    {
        public Task CreateAsync(Doacao model, CancellationToken cancellationToken);
        Task<Doacao?> GetLastDonationAsync(int doadorId, CancellationToken cancellationToken);
    }
}
