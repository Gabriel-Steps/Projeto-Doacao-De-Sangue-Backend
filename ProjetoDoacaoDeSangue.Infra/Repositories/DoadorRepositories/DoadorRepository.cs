using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly ProjetoDbContext _context;

        public DoadorRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doador>> GetAllAsync(CancellationToken cancellationToken)
        {
            var doadores = await _context.Doadores.ToListAsync(cancellationToken);
            return doadores;
        }

        public async Task<Doador?> GetById(int id, CancellationToken cancellationToken)
        {
            var doador = await _context.Doadores.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
            return doador;
        }

        public async Task<List<Doacao>> GetDonationHistory(int id, CancellationToken cancellationToken)
        {
            var doacoes = await _context.Doacoes
                .AsNoTracking()
                .Where(d => d.DoadorId == id)
                .ToListAsync();

            return doacoes;
        }
        public async Task CreateAsync(Doador model, CancellationToken cancellationToken)
        {
            await _context.Doadores.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Doador?> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Doadores.SingleOrDefaultAsync(d => d.Email == email, cancellationToken);
        }

        public async Task Delete(Doador model, CancellationToken cancellationToken)
        {
            _context.Doadores.Remove(model);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Doador model, CancellationToken cancellationToken)
        {
            _context.Doadores.Update(model);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
