using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Repositories.EstoqueDeSangueRepositories;

namespace ProjetoDoacaoDeSangue.Application.Queries.EstoqueSangueQuerys.GetByTypeBloodAsync
{
    public class GetAllEstoqueSangueAsyncQueryHandler : IRequestHandler<GetAllEstoqueSangueAsyncQuery, List<EstoqueSangue>>
    {
        private readonly IEstoqueDeSangueRepository _repository;

        public GetAllEstoqueSangueAsyncQueryHandler(IEstoqueDeSangueRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EstoqueSangue>> Handle(GetAllEstoqueSangueAsyncQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
