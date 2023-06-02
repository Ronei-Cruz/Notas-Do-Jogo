namespace NotasDoJogo.Application.Dtos
{
    public class NotaDto
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        public int UsuarioId { get; set; }
        public int PartidaId { get; set; }
        public int Valor { get; set; }
    }
}