using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeSangue.Application.Commands.EnderecoCommands.CreateEnderecoAsync
{
    public class CreateEnderecoAsyncCommand : IRequest<Unit>
    {
        [Required]
        public int DoadorId { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "UF is required")]
        public string UF { get; set; } = string.Empty;

        [Required(ErrorMessage = "CEP is required")]
        public string CEP { get; set; } = string.Empty;
    }
}
