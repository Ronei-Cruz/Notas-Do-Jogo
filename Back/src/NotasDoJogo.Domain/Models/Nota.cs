using System.ComponentModel.DataAnnotations;

namespace NotasDoJogo.Domain.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        public Jogador Jogador { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }
        public int Valor { get; set; }
    }
}