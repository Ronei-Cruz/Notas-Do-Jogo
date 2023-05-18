using System.ComponentModel.DataAnnotations;

namespace NotasDoJogo.Domain.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Jogador Jogador { get; set; }
        public decimal Pontuacao { get; set; }
    }
}