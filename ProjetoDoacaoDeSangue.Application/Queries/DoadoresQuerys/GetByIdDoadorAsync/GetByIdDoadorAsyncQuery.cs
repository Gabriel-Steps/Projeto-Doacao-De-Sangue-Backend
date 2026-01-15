using MediatR;
using ProjetoDoacaoDeSangue.Application.ViewModels.DoadorViewModels;

namespace ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetByIdDoadorAsync
{
    public class GetByIdDoadorAsyncQuery : IRequest<GetDataDoadorViewDto>
    {
        public int Id { get; private set; }

        public GetByIdDoadorAsyncQuery(int id)
        {
            Id = id;
        }
    }
}
