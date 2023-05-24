namespace NotasDoJogo.Domain.Models
{
    public class Partida
    {
        public int Id { get; set; }
        public string Jogo { get; set; }
        public DateTime Data { get; set; }
        public List<Nota> Notas { get; set; }
    }
}