using MediatR;
using ProjetoDoacaoDeSangue.Application.Exceptions.EnderecoExceptions;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Repositories.EnderecoRepositories;

namespace ProjetoDoacaoDeSangue.Application.Queries.EnderecoQuerys.GetByIdDoadorEnderecoAsync
{
    public class GetByIdDoadorEnderecoAsyncQueryHandler : IRequestHandler<GetByIdDoadorEnderecoAsyncQuery, Endereco>
    {
        private readonly IEnderecoRepository _repository;

        public GetByIdDoadorEnderecoAsyncQueryHandler(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Endereco> Handle(GetByIdDoadorEnderecoAsyncQuery request, CancellationToken cancellationToken)
        {
            var endereco = await _repository.GetByIdDoadorAsync(request.Id, cancellationToken) ??
                throw new ThisDonorsAddressWasNotFoundException(request.Id);

            return endereco;
        }
    }
}
