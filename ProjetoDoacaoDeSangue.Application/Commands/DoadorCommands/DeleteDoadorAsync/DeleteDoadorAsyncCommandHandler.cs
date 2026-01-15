using MediatR;
using ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.DeleteDoadorAsync
{
    public class DeleteDoadorAsyncCommandHandler : IRequestHandler<DeleteDoadorAsyncCommand, Unit>
    {
        private readonly IDoadorRepository _repository;

        public DeleteDoadorAsyncCommandHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDoadorAsyncCommand request, CancellationToken cancellationToken)
        {
            var doador = await _repository.GetById(request.Id, cancellationToken) ??
                throw new DonorNotFoundException(request.Id);

            await _repository.Delete(doador, cancellationToken);

            return Unit.Value;
        }
    }
}
