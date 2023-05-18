namespace NotasDoJogo.Domain.Models
{
    public class Partida
    {
        public int Id { get; set; }
        public List<PartidaNota> PartidasNotas { get; set; }
    }
}