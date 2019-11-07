namespace WebSalao.Domain.Cadasto
{
    public class Fornecedor
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

    }
}
