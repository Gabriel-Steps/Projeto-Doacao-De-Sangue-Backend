using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;

namespace ProjetoDoacaoDeSangue.Application.Queries.EnderecoQuerys.GetByIdDoadorEnderecoAsync
{
    public class GetByIdDoadorEnderecoAsyncQuery : IRequest<Endereco>
    {
        public int Id { get; set; }

        public GetByIdDoadorEnderecoAsyncQuery(int id) 
        {
            Id = id;
        }
    }
}
