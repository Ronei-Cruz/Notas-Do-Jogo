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
            modelBuilder.Entity<Jogador>()
                .HasMany(j => j.Notas)
                .WithOne(n => n.Jogador)
                .HasForeignKey(n => n.JogadorId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Notas)
                .WithOne(n => n.Usuario)
                .HasForeignKey(n => n.UsuarioId);

            modelBuilder.Entity<Partida>()
                .HasMany(p => p.Notas)
                .WithOne(n => n.Partida)
                .HasForeignKey(n => n.PartidaId);
        }    
    }
}