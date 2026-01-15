using ProjetoDoacaoDeSangue.Core.Enums;

namespace ProjetoDoacaoDeSangue.Application.ViewModels.DoadorViewModels
{
    public class GetDataDoadorViewDto
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public Generos Genero { get; set; }
        public double Peso { get; set; }
        public TiposSanguineos TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
    }
}
