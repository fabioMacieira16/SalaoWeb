namespace WebSalao.Domain.Cadasto
{
    public class ContasCliente
    {
        public int ContaId { get; set; }
        public Contas Contas { get; set; }
        public int ClienteId { get; set; }
        public Cliente Clientes { get; set; }
    }
}