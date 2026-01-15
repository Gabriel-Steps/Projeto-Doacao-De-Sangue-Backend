using MediatR;
using ProjetoDoacaoDeSangue.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.UpdateDoadorAsync
{
    public class UpdateDoadorAsyncCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Nome Completo obrigatório!")]
        //[MinLength(3, ErrorMessage = "Nome muito curto!")]
        public string NomeCompleto { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        //[Required]
        //[Range(50, 500, ErrorMessage = "Peso mínimo para doação é 50kg")]
        public double Peso { get; set; }

        //[Required]
        public TiposSanguineos TipoSanguineo { get; set; }

        //[Required]
        public string FatorRh { get; set; } = string.Empty;
    }
}
