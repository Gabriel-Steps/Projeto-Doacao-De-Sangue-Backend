using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoacaoCommands.CreateDoacaoAsync
{
    public class CreateDoacaoAsyncCommand : IRequest<Unit>
    {
        [Required]
        public int DoadorId { get; set; }

        [Required(ErrorMessage = "Date of donation is required")]
        public DateTime DataDoacao { get; set; }

        [Required(ErrorMessage = "Quantity in ML is required")]
        public int QuantidadeMl { get; set; }
    }
}
