using MediatR;
using ProjetoDoacaoDeSangue.Infra.Models.EnderecoModels;
using ProjetoDoacaoDeSangue.Infra.Repositories.EnderecoRepositories;

namespace ProjetoDoacaoDeSangue.Application.Queries.EnderecoQuerys.GetEnderecoByCepAsync
{
    public class GetEnderecoByCepQueryHandler : IRequestHandler<GetEnderecoByCepQuery, EnderecoViaCepDto>
    {
        private readonly IEnderecoRepository _repository;

        public GetEnderecoByCepQueryHandler(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<EnderecoViaCepDto> Handle(GetEnderecoByCepQuery request, CancellationToken cancellationToken)
        {
            return await _repository.BuscarEnderecoAsync(request.Cep);
        }
    }
}
