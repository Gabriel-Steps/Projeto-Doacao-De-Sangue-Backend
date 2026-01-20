using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Application.Queries.EstoqueSangueQuerys.GetByTypeBloodAsync
{
    public class GetAllEstoqueSangueAsyncQuery : IRequest<List<EstoqueSangue>> { }
}
