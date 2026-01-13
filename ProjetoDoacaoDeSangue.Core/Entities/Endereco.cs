namespace ProjetoDoacaoDeSangue.Core.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public Doador Doador { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
    }
}
