using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Models.EnderecoModels;

namespace ProjetoDoacaoDeSangue.Infra.Repositories.EnderecoRepositories
{
    public interface IEnderecoRepository
    {
        public Task<EnderecoViaCepDto> BuscarEnderecoAsync(string cep);
        public Task CreateAsync(Endereco model, CancellationToken cancellationToken);
        public Task<Endereco?> GetByIdDoadorAsync(int id, CancellationToken cancellationToken);
    }
}
