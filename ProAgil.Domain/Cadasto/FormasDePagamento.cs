
namespace WebSalao.Domain.Cadasto
{
    public class FormasDePagamento
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string Sigla { get; set; }
        public string Especie { get; set; }
    }
}
