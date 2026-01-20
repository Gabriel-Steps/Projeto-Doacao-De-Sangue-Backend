using MediatR;
using ProjetoDoacaoDeSangue.Application.Exceptions.EstoqueSangueExceptions;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Infra.Repositories.EstoqueDeSangueRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDoacaoDeSangue.Application.Commands.EstoqueSangueCommands.UpsertEstoqueSangueAsync
{
    public class UpsertEstoqueSangueAsyncCommandHandler : IRequestHandler<UpsertEstoqueSangueAsyncCommand, Unit>
    {
        private readonly IEstoqueDeSangueRepository _repository;

        public UpsertEstoqueSangueAsyncCommandHandler(IEstoqueDeSangueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpsertEstoqueSangueAsyncCommand request, CancellationToken cancellationToken)
        {
            var estoqueSangue = await _repository.GetByTypeBloodAsync(request.TiposSanguineo, cancellationToken) ??
                throw new BloodSupplyNotFoundException();

            if(estoqueSangue != null)
            {
                estoqueSangue.QuantidadeMl += request.QuantidadeMl;
                await _repository.UpdateAsync(estoqueSangue, cancellationToken);
            }
            else
            {
                var newBloodSupply = new EstoqueSangue()
                {
                    TiposSanguineo = request.TiposSanguineo,
                    FatorRH = request.FatorRH,
                    QuantidadeMl = request.QuantidadeMl
                };
                await _repository.CreateAsync(newBloodSupply, cancellationToken);
            }

            return Unit.Value;
        }
    }
}
