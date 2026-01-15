using MediatR;
using ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.UpdateDoadorAsync
{
    public class UpdateDoadorAsyncCommandHandler : IRequestHandler<UpdateDoadorAsyncCommand, Unit>
    {
        private readonly IDoadorRepository _repository;

        public UpdateDoadorAsyncCommandHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDoadorAsyncCommand request, CancellationToken cancellationToken)
        {
            var doador = await _repository.GetById(request.Id, cancellationToken) ??
                throw new DonorNotFoundException(request.Id);

            doador.AtualizarDados(request.NomeCompleto,
               request.DataNascimento,
               request.Peso,
               request.TipoSanguineo,
               request.FatorRh
            );

            await _repository.Update(doador, cancellationToken);

            return Unit.Value;
        }
    }
}
