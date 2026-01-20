using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Core.Enums;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.EstoqueDeSangueRepositories
{
    public class EstoqueDeSangueRepository : IEstoqueDeSangueRepository
    {
        private readonly ProjetoDbContext _context;

        public EstoqueDeSangueRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(EstoqueSangue model, CancellationToken cancellationToken)
        {
            await _context.EstoqueSangues.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<EstoqueSangue>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.EstoqueSangues
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EstoqueSangue?> GetByTypeBloodAsync(TiposSanguineos tipo, CancellationToken cancellationToken)
        {
            return await _context.EstoqueSangues
                .SingleOrDefaultAsync(e => e.TiposSanguineo == tipo, cancellationToken);
                
        }

        public async Task UpdateAsync(EstoqueSangue model, CancellationToken cancellationToken)
        {
            _context.EstoqueSangues.Update(model);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
