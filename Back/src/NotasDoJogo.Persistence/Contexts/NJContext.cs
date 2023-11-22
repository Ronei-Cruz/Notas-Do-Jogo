using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Persistence.Contexts
{
    public class NJContext : DbContext
    {
        public NJContext(DbContextOptions<NJContext> options) : base(options)
        {
        }

        public DbSet<UsuarioResponse> Usuarios { get; set; }
        public DbSet<JogadorResponse> Jogadores { get; set; }
        public DbSet<PartidaResponse> Partidas { get; set; }
        public DbSet<NotaResponse> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JogadorResponse>()
                .HasMany(j => j.Notas)
                .WithOne(n => n.Jogador)
                .HasForeignKey(n => n.JogadorId);

            modelBuilder.Entity<UsuarioResponse>()
                .HasMany(u => u.Notas)
                .WithOne(n => n.Usuario)
                .HasForeignKey(n => n.UsuarioId);

            modelBuilder.Entity<PartidaResponse>()
                .HasMany(p => p.Notas)
                .WithOne(n => n.Partida)
                .HasForeignKey(n => n.PartidaId);
        }
        
    }
}