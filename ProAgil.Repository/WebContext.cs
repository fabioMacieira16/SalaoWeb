using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSalao.Domain;
using WebSalao.Domain.Cadasto;
using WebSalao.Domain.Identity;

namespace WebSalao.Respository
{
    public class WebContext : IdentityDbContext<User, Role, int,
                              IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                              IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        //Cadastro
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContasCorrente> ContaCorrentes { get; set; }
        public DbSet<FormasDePagamento> FormasDePagamentos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Lojas> Lojas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoLancamento> TipoLancamento { get; set; }
        public DbSet<SubTipoLancamento> SubTipoLancamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                    userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                    userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                }
            );

            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }
    }
}