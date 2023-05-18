namespace NotasDoJogo.Application.Dtos
{
    public class NotaDTO
    {
        public UsuarioDTO Usuario { get; set; }
        public JogadorDTO Jogador { get; set; }
        public decimal Pontuacao { get; set; }
    }
}