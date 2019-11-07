using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSalao.Domain;
using WebSalao.Domain.Cadasto;
using WebSalao.Respository;

namespace WebSalao.Repository
{
    public class WebRepository : IRepository
    {
        private readonly WebContext _context;
        public WebRepository(WebContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region -- GERAIS --
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        #endregion

        #region -- EVENTO --
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                        .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.AsNoTracking()
                        .OrderByDescending(c => c.DataEvento)
                        .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(c => c.Id)
                        .Where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
        #endregion

        #region -- PALESTRANTE -- 
        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking()
                    .OrderBy(p => p.Nome)
                    .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking()
                        .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
        #endregion

        #region -- PRODUTOS --
        public async Task<Produto[]> GetAllProdutoAsync(bool includeFornecedor = false)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(c => c.Fornecedor);

            query = query.AsNoTracking()
                .OrderBy(c => c.ID);

            return await query.ToArrayAsync();

        }
        public async Task<Produto[]> GetAllProdutoAsyncByDescricao(string descricao, bool includeFornecedor)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(c => c.CategoriaId)
                .Include(c => c.Fornecedor);

            query = query.AsNoTracking()
                    .OrderByDescending(c => c.Descricao)
                    .Where(c => c.Descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Produto> GetProdutoAsyncById(int ProdutoId, bool includeFornecedor)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(c => c.CategoriaId)
                .Include(c => c.Fornecedor);

            query = query
                    .AsNoTracking()
                    .OrderBy(c => c.ID)
                    .Where(c => c.ID == ProdutoId);

            return await query.FirstOrDefaultAsync();

        }
        #endregion

        #region -- CONTAS --
        public Task<Contas[]> GetAllContasAsyncByDescricao(string descricao, bool includeTipoLancamento)
        {
            throw new System.NotImplementedException();
        }
        public Task<Contas[]> GetAllContasAsync(bool includeTipoLancamento)
        {
            throw new System.NotImplementedException();
        }
        public Task<Contas> GetcontasAsyncById(bool includeTipoLancamento)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region -- CLIENTES --
        public Task<Cliente[]> GetAllClientesAsyncByDescricao(string descricao, bool includeContas)
        {
            throw new System.NotImplementedException();
        }
        public Task<Cliente[]> GetAllClientesAsync(bool includeContas)
        {
            throw new System.NotImplementedException();
        }
        public Task<Cliente> GetClientesAsyncById(bool includeContas)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}