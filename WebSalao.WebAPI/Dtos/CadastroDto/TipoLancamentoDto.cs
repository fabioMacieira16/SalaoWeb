using System.ComponentModel.DataAnnotations.Schema;

namespace WebSalao.WebAPI.Dtos.CadastroDto
{
    public class TipoLancamentoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string SubTipo { get; set; }

        [ForeignKey("SubTipoLancamentosDto")]
        public int SubTipoLancamentoDtoId { get; set; }
        public virtual SubTipoLancamentosDto SubTipoLancamentosDto { get; set; }

    }
}
