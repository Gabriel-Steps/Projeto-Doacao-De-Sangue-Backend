using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetDonationHistoryAsync
{
    public class GetDonationHistoryAsyncQueryHandler : IRequestHandler<GetDonationHistoryAsyncQuery, List<Doacao>>
    {
        private readonly IDoadorRepository _repository;

        public GetDonationHistoryAsyncQueryHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Doacao>> Handle(GetDonationHistoryAsyncQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDonationHistory(request.Id, cancellationToken);
        }
    }
}
