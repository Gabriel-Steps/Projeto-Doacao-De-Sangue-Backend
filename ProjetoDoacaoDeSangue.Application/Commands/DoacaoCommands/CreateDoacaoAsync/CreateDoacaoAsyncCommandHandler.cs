using MediatR;
using ProjetoDoacaoDeSangue.Application.Exceptions.DoacaoExceptions;
using ProjetoDoacaoDeSangue.Application.Exceptions.DoadorExceptions;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Core.Enums;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoacaoRepositories;
using ProjetoDoacaoDeSangue.Infra.Repositories.DoadorRepositories;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoacaoCommands.CreateDoacaoAsync
{
    public class CreateDoacaoAsyncCommandHandler : IRequestHandler<CreateDoacaoAsyncCommand, Unit>
    {
        private readonly IDoacaoRepository _doacaoRepository;
        private readonly IDoadorRepository _doadorRepository;

        public CreateDoacaoAsyncCommandHandler(IDoacaoRepository doacaoRepository, IDoadorRepository doadorRepository)
        {
            _doacaoRepository = doacaoRepository;
            _doadorRepository = doadorRepository;
        }

        public async Task<Unit> Handle(CreateDoacaoAsyncCommand request, CancellationToken cancellationToken)
        {
            var doador = await _doadorRepository.GetById(request.DoadorId, cancellationToken)
                ?? throw new DonorNotFoundException(request.DoadorId);

            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - doador.DataNascimento.Year;
            if (idade < 18) throw new MinorsCannotDonateBloodException();

            var ultimaDoacao = await _doacaoRepository.GetLastDonationAsync(request.DoadorId, cancellationToken);

            if (ultimaDoacao != null)
            {
                var podeDoar = doador.PodeDoar(
                    ultimaDoacao.DataDoacao,
                    DateTime.UtcNow);

                if (!podeDoar)
                {
                    var dias = doador.Genero == Generos.Homem ? 60 : 90;
                    throw new DonationIntervalNotAllowedException(dias);
                }
            }

            var doacao = new Doacao
            {
                DoadorId = request.DoadorId,
                DataDoacao = DateTime.UtcNow,
                QuantidadeMl = request.QuantidadeMl
            };

            await _doacaoRepository.CreateAsync(doacao, cancellationToken);

            return Unit.Value;
        }
    }
}
