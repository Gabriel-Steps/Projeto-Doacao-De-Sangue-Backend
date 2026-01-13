namespace ProjetoDoacaoDeSangue.Core.Entities
{
    public class Doacao
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public Doador Doador { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeMl { get; set; }
    }
}
