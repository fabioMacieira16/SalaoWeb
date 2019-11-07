using System.ComponentModel.DataAnnotations.Schema;

namespace WebSalao.Domain.Cadasto
{
    public class ContasCorrente
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }

        public int ContasID { get; set; }
        public virtual Contas Contas { get; set; }

    }
}
