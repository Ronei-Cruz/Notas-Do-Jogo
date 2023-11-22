using System.Globalization;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;

namespace NotasDoJogo.Persistence.Seeders
{
    public class DbSeeder
    {
        readonly Random random = new();
        public void SeedData(NJContext dbContext)
        {
            SeedJogadores(dbContext);
            SeedPartidas(dbContext);
            SeedUsuarios(dbContext);
            SeedNotas(dbContext);

        }

        private static void SeedJogadores(NJContext dbContext)
        {
            var jogadores = new List<JogadorResponse>
            {
                new Jogador { Nome = "João Paulo", Posicao = "Goleiro", Idade = 27 },
                new Jogador { Nome = "Gabriel Inocencio", Posicao = "Lateral", Idade = 28 },
                new Jogador { Nome = "Lucas Pires", Posicao = "Lateral", Idade = 22 },
                new Jogador { Nome = "Messias", Posicao = "Zagueiro", Idade = 28 },
                new Jogador { Nome = "Joaquim", Posicao = "Zaguerio", Idade = 24 },
                new Jogador { Nome = "Rodrigo Fernández", Posicao = "Meia", Idade = 27},
                new Jogador { Nome = "Dodi", Posicao = "Meia", Idade = 26},
                new Jogador { Nome = "Lucas Lima", Posicao = "Meia", Idade = 32},
                new Jogador { Nome = "Ângelo Gabriel", Posicao = "Atacante", Idade = 18},
                new Jogador { Nome = "Deivid Washington", Posicao = "Atacante", Idade = 17},
                new Jogador { Nome = "Soteldo", Posicao = "Atacante", Idade = 25},
                new Jogador { Nome = "Odair Hellman", Posicao = "Técnico", Idade = 58 },
            };

            dbContext.Jogadores.AddRange(jogadores);
            dbContext.SaveChanges();
        }

        private static void SeedPartidas(NJContext dbContext)
        {
            var partidas = new List<PartidaResponse>
            {
                new Partida {Jogo = "Bahia x Santos", Data = DateTime.ParseExact("2023-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture)},
                new Partida {Jogo = "Santos x Internacional", Data = DateTime.ParseExact("2023-06-03", "yyyy-MM-dd", CultureInfo.InvariantCulture)},
                new Partida {Jogo = "Santos x Newell's Old Boys", Data = DateTime.ParseExact("2023-06-06", "yyyy-MM-dd", CultureInfo.InvariantCulture)},
            };

            dbContext.Partidas.AddRange(partidas);
            dbContext.SaveChanges();
        }

        private static void SeedUsuarios(NJContext dbContext)
        {
            var usuarios = new List<UsuarioResponse>
            {
                new Usuario { Nome = "Noronha Love", Email = "noronha@teste.com" },
                new Usuario { Nome = "Murillo Tauro", Email = "murillo@teste.com" },
                new Usuario { Nome = "João Canalha", Email = "joaocanalha@teste.com" },
            };

            dbContext.Usuarios.AddRange(usuarios);
            dbContext.SaveChanges();
        }

        private void SeedNotas(NJContext dbContext)
        {
            
            var notas = new List<NotaResponse>
            {
                new Nota {JogadorId = 1, UsuarioId = 1, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 1, UsuarioId = 2, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 1, UsuarioId = 3, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 2, UsuarioId = 1, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 2, UsuarioId = 2, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 2, UsuarioId = 3, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 3, UsuarioId = 1, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 3, UsuarioId = 2, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 3, UsuarioId = 3, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 4, UsuarioId = 1, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 4, UsuarioId = 2, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 4, UsuarioId = 3, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 1, UsuarioId = 1, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 1, UsuarioId = 2, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 1, UsuarioId = 3, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 2, UsuarioId = 1, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 2, UsuarioId = 2, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 2, UsuarioId = 3, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 3, UsuarioId = 1, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 3, UsuarioId = 2, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 3, UsuarioId = 3, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 4, UsuarioId = 1, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 4, UsuarioId = 2, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 4, UsuarioId = 3, PartidaId = 2, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 11, UsuarioId = 1, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 11, UsuarioId = 2, PartidaId = 1, Valor = random.Next(4, 11) },
                new Nota {JogadorId = 11, UsuarioId = 3, PartidaId = 1, Valor = random.Next(4, 11) } ,
            };

            dbContext.Notas.AddRange(notas);
            dbContext.SaveChanges();
        }
    }
}