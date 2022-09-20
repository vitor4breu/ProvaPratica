namespace Dominio.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public int TipoId { get; set; }
        public int SituacaoId { get; set; }
    }
}
