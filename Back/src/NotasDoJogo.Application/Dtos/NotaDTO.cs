namespace NotasDoJogo.Application.Dtos
{
    public class NotaDTO
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        public JogadorDTO Jogador { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int PartidaId { get; set; }
        public PartidaDTO Partida { get; set; }
        public int Valor { get; set; }
    }
}