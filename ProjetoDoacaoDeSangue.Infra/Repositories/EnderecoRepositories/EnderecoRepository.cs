using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Models.EnderecoModels;
using System.Net.Http.Json;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.EnderecoRepositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ProjetoDbContext _context;

        public EnderecoRepository(HttpClient httpClient, ProjetoDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<EnderecoViaCepDto> BuscarEnderecoAsync(string cep)
        {
            var response = await _httpClient.GetFromJsonAsync<EnderecoViaCepDto>(
            $"https://viacep.com.br/ws/{cep}/json/");

            if (response == null || response.Erro)
                throw new Exception("CEP not found.");

            return response;
        }

        public async Task CreateAsync(Endereco model, CancellationToken cancellationToken)
        {
            await _context.Enderecos.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Endereco?> GetByIdDoadorAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Enderecos.SingleOrDefaultAsync(e => e.DoadorId == id, cancellationToken);
        }
    }
}
