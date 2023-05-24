namespace NotasDoJogo.Domain.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int Idade { get; set; }
        public List<Nota> Notas { get; set; }
        
    }
}