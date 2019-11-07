
using System.Collections.Generic;

namespace WebSalao.Domain.Cadasto
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string Endereço { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Telefones { get; set; }
        public string Celular { get; set; }
        public string EMail { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Observacao { get; set; }

        //Relacao Cliente e contas
        public List<ContasCliente> ContasClientes { get; set; }

    }
}
