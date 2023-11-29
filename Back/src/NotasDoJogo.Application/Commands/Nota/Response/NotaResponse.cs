using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Usuario.Response;

namespace NotasDoJogo.Application.Commands.Nota.Response;

public class NotaResponse : ApiResponse
{
    public int Id { get; set; }
    public int JogadorId { get; set; }
    public JogadorResponse Jogador { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioResponse Usuario { get; set; }
    public int PartidaId { get; set; }
    public PartidaResponse Partida { get; set; }
    public int Valor { get; set; }
}
