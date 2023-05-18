using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contexts
{
    public class NJContext : DbContext
    {
        public NJContext(DbContextOptions<NJContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartidaNota>()
                .HasKey(pn => new { pn.PartidaId, pn.NotaId });

            modelBuilder.Entity<PartidaNota>()
                .HasOne(pn => pn.Partida)
                .WithMany(p => p.PartidasNotas)
                .HasForeignKey(pn => pn.PartidaId);

            modelBuilder.Entity<PartidaNota>()
                .HasOne(pn => pn.Nota)
                .WithMany()
                .HasForeignKey(pn => pn.NotaId);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}