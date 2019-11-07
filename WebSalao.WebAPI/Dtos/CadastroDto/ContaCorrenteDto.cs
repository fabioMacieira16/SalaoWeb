
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSalao.WebAPI.Dtos.CadastroDto
{
    public class ContaCorrenteDto
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public bool ativo { get; set; }

        [ForeignKey("ContasDto")]
        public int ContasID { get; set; }
        public virtual ContasDto ContasDto { get; set; }
    }
}
