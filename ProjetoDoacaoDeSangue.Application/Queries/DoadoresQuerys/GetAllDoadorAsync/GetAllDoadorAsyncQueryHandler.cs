using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetAllDoadorAsync
{
    public class GetAllDoadorAsyncQueryHandler : IRequestHandler<GetAllDoadorAsyncQuery, List<Doador>>
    {
        private readonly IDoadorRepository _repository;

        public GetAllDoadorAsyncQueryHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Doador>> Handle(GetAllDoadorAsyncQuery request, CancellationToken cancellationToken)
        {
            var doadores = await _repository.GetAllAsync(cancellationToken);
            return doadores;
        }
    }
}
