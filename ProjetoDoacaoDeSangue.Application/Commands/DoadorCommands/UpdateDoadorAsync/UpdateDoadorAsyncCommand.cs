using MediatR;
using ProjetoDoacaoDeSangue.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.UpdateDoadorAsync
{
    public class UpdateDoadorAsyncCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required!")]
        [MinLength(3, ErrorMessage = "Very short name!")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Weight is required!")]
        [Range(50, 500, ErrorMessage = "The minimum weight for donation is 50 kg.")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "You must provide your blood type!")]
        public TiposSanguineos TipoSanguineo { get; set; }

        [Required(ErrorMessage = "Enter your HR Factor!")]
        public string FatorRh { get; set; } = string.Empty;
    }
}
