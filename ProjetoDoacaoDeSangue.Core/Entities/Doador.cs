using ProjetoDoacaoDeSangue.Core.Enums;

namespace ProjetoDoacaoDeSangue.Core.Entities
{
    public class Doador
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public Generos Genero { get; set; }
        public double Peso { get; set; }
        public TiposSanguineos TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
    }
}
