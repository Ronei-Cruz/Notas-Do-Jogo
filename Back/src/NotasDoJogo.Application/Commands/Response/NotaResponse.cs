namespace NotasDoJogo.Application.Commands.Response;

public class NotaResponse : ApiResponse
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
