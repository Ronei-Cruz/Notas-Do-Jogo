namespace NotasDoJogo.Application.Dtos
{
    public class JogadorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int Idade { get; set; }
        public List<NotaDTO> Notas { get; set; }
    }
}