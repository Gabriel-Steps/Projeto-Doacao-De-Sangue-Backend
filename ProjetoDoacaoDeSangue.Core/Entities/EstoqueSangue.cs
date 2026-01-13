using ProjetoDoacaoDeSangue.Core.Enums;

namespace ProjetoDoacaoDeSangue.Core.Entities
{
    public class EstoqueSangue
    {
        public int Id { get; set; }
        public TiposSanguineos TiposSanguineo { get; set; }
        public string FatorRH { get; set; } = string.Empty;
        public int QuantidadeMl { get; set; }
    }
}
