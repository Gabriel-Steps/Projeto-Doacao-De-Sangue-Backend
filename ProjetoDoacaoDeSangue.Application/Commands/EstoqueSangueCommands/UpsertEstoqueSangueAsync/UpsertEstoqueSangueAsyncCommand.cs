using MediatR;
using ProjetoDoacaoDeSangue.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeSangue.Application.Commands.EstoqueSangueCommands.UpsertEstoqueSangueAsync
{
    public class UpsertEstoqueSangueAsyncCommand : IRequest<Unit>
    {
        [Required(ErrorMessage = "Providing your blood type is required.")]
        public TiposSanguineos TiposSanguineo { get; set; }

        [Required(ErrorMessage = "Report the HR Factor")]
        public string FatorRH { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity in ML is required")]
        public int QuantidadeMl { get; set; }
    }
}
