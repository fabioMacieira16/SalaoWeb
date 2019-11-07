using System.Threading.Tasks;
using WebSalao.Domain;
using WebSalao.Domain.Cadasto;

namespace WebSalao.Repository
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;

        Task<bool> SaveChangesAsync();

        //EVENTOS Implementa no WebRepository
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes);

        //PALESTRANTE Implementa no WebRepository
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos);
        Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos);


        //Produtos Implementa no WebRepository
        Task<Produto[]> GetAllProdutoAsyncByDescricao(string descricao, bool includeFornecedor);
        Task<Produto[]> GetAllProdutoAsync(bool includeFornecedor);
        Task<Produto> GetProdutoAsyncById(int ProdutoId, bool includeFornecedor);

        //Contas Implementa no WebRepository
        Task<Contas[]> GetAllContasAsyncByDescricao(string descricao, bool includeTipoLancamento);
        Task<Contas[]> GetAllContasAsync(bool includeTipoLancamento);
        Task<Contas> GetcontasAsyncById(bool includeTipoLancamento);

        //Clientes Implementa no WebRepository
        Task<Cliente[]> GetAllClientesAsyncByDescricao(string descricao, bool includeContas);
        Task<Cliente[]> GetAllClientesAsync(bool includeContas);
        Task<Cliente> GetClientesAsyncById(int ClienteId, bool includeContas);


    }
}