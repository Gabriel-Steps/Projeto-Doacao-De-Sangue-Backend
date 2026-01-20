using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.DoacaoRepositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly ProjetoDbContext _context;

        public DoacaoRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Doacao model, CancellationToken cancellationToken)
        {
            await _context.Doacoes.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Doacao?> GetLastDonationAsync(int doadorId, CancellationToken cancellationToken)
        {
            return await _context.Doacoes
                .Where(d => d.DoadorId == doadorId)
                .OrderByDescending(d => d.DataDoacao)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
