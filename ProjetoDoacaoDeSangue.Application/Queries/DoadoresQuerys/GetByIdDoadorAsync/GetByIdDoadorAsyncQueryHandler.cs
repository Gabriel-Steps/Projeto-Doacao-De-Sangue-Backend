using MediatR;
using ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions;
using ProjetoDoacaoDeSangue.Application.ViewModels.DoadorViewModels;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetByIdDoadorAsync
{
    public class GetByIdDoadorAsyncQueryHandler : IRequestHandler<GetByIdDoadorAsyncQuery, GetDataDoadorViewDto>
    {
        private readonly IDoadorRepository _repository;

        public GetByIdDoadorAsyncQueryHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDataDoadorViewDto> Handle(GetByIdDoadorAsyncQuery request, CancellationToken cancellationToken)
        {
            var doador = await _repository.GetById(request.Id, cancellationToken) ??
                throw new DonorNotFoundException(request.Id);

            var viewDoador = new GetDataDoadorViewDto()
            {
                NomeCompleto = doador.NomeCompleto,
                Email = doador.Email,
                DataNascimento = doador.DataNascimento,
                Genero = doador.Genero,
                Peso = doador.Peso,
                TipoSanguineo = doador.TipoSanguineo,
                FatorRh = doador.FatorRh
            };

            return viewDoador;
        }
    }
}
