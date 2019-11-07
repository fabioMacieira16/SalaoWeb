
using System.Collections.Generic;

namespace WebSalao.Domain.Cadasto
{
    public class Produto
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }
        public double Preco { get; set; }

        public List<Fornecedor> Fornecedor { get; set; }

    }
}
