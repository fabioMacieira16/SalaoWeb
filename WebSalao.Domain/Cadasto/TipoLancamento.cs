using System.ComponentModel.DataAnnotations.Schema;

namespace WebSalao.Domain.Cadasto
{
    public class TipoLancamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string SubTipo { get; set; }

        [ForeignKey("SubTipoLancamento")]
        public int SubTipoLancamentoId { get; set; }
        public virtual SubTipoLancamento SubTipoLancamentos { get; set; }

    }
}
