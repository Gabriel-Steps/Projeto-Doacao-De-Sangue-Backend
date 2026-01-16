using MediatR;
using ProjetoDoacaoDeSangue.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.CreateDoadorAsync
{
    public class CreateDoadorAsyncCommand : IRequest<int>
    {
        [Required(ErrorMessage = "Full name is required!")]
        [MinLength(3, ErrorMessage = "Very short name!")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(5, ErrorMessage = "Very short password!")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public Generos Genero { get; set; }

        [Required(ErrorMessage = "Weight is required!")]
        [Range(50, 500, ErrorMessage = "The minimum weight for donation is 50 kg.")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "You must provide your blood type!")]
        public TiposSanguineos TipoSanguineo { get; set; }

        [Required(ErrorMessage = "Enter your HR Factor!")]
        public string FatorRh { get; set; } = string.Empty;
    }
}
