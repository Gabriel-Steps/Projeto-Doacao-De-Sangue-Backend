using MediatR;
using ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.CreateDoadorAsync
{
    public class CreateDoadorAsyncCommandHandler : IRequestHandler<CreateDoadorAsyncCommand, int>
    {
        private readonly IDoadorRepository _repository;

        public CreateDoadorAsyncCommandHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateDoadorAsyncCommand request, CancellationToken cancellationToken)
        {
            var doador = await _repository.GetByEmail(request.Email, cancellationToken);

            if (doador != null) throw new EmailAlreadyExistsException(request.Email);

            var newDoador = new Doador()
            {
                NomeCompleto = request.NomeCompleto,
                Email = request.Email,
                Password = request.Password,
                DataNascimento = request.DataNascimento,
                Genero = request.Genero,
                Peso = request.Peso,
                TipoSanguineo = request.TipoSanguineo,
                FatorRh = request.FatorRh
            };

            await _repository.CreateAsync(newDoador, cancellationToken);
            return newDoador.Id;
        }
    }
}
