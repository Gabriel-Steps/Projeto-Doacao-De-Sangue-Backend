using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetAllDoadorAsync
{
    public class GetAllDoadorAsyncQuery : IRequest<List<Doador>>
    {
    }
}
