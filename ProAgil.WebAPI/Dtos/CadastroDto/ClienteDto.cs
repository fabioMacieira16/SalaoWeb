using System.Collections.Generic;

namespace WebSalao.WebAPI.Dtos.CadastroDto
{
    public class ClienteDto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
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
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string Observacao { get; set; }

        public List<ContasDto> Contas { get; set; }

        //[ForeignKey("ContasDto")]
        //public int ContaId { get; set; }
        //public virtual ContasDto ContasDto { get; set; }

    }
}
