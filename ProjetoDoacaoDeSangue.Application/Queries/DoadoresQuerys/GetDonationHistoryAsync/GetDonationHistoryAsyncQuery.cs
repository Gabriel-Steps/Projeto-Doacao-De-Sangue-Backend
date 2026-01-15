using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetDonationHistoryAsync
{
    public class GetDonationHistoryAsyncQuery : IRequest<List<Doacao>>
    {
        public int Id { get; private set; }

        public GetDonationHistoryAsyncQuery(int id)
        {
            Id = id;
        }
    }
}
