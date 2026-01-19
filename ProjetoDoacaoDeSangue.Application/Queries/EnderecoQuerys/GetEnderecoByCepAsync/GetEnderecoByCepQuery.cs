using MediatR;
using ProjetoDoacaoDeSangue.Infra.Models.EnderecoModels;
 
namespace ProjetoDoacaoDeSangue.Application.Queries.EnderecoQuerys.GetEnderecoByCepAsync
{
    public class GetEnderecoByCepQuery : IRequest<EnderecoViaCepDto>
    {
        public string Cep { get; }

        public GetEnderecoByCepQuery(string cep)
        {
            Cep = cep;
        }
    }
}
