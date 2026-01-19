using MediatR;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Repositories.EnderecoRepositories;

namespace ProjetoDoacaoDeSangue.Application.Commands.EnderecoCommands.CreateEnderecoAsync
{
    public class CreateEnderecoAsyncCommandHandler : IRequestHandler<CreateEnderecoAsyncCommand, Unit>
    {
        private readonly IEnderecoRepository _repository;

        public CreateEnderecoAsyncCommandHandler(IEnderecoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(CreateEnderecoAsyncCommand request, CancellationToken cancellationToken)
        {
            var endereco = new Endereco()
            {
                DoadorId = request.DoadorId,
                Logradouro = request.Logradouro,
                Cidade = request.Cidade,
                UF = request.UF,
                CEP = request.CEP
            };

            await _repository.CreateAsync(endereco, cancellationToken);

            return Unit.Value;
        }
    }
}
