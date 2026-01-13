using ProjetoDoacaoDeSangue.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDoacaoDeSangue.Application.Services.DoadorServices.InputModels
{
    public class CreateDoadorInputDto
    {
        [Required(ErrorMessage= "Nome Completo obrigatório!")]
        [MinLength(3, ErrorMessage= "Nome muito curto!")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória!")]
        [MinLength(5, ErrorMessage = "Senha muito curta!")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Range(50, 500, ErrorMessage = "Peso mínimo para doação é 50kg")]
        public double Peso { get; set; }

        [Required]
        public TiposSanguineos TipoSanguineo { get; set; }

        [Required]
        public string FatorRh { get; set; } = string.Empty;
    }
}
