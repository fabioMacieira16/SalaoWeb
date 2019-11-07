namespace WebSalao.WebAPI.Dtos
{
    public class ProdutosDto
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }
        public int Fornecedor { get; set; }
        public double Preco { get; set; }

    }
}
