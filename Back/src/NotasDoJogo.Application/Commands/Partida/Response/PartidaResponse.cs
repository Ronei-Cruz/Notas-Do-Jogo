using NotasDoJogo.Application.Commands.Nota.Response;

namespace NotasDoJogo.Application.Commands.Partida.Response;

public class PartidaResponse : ApiResponse
{
    public int Id { get; set; }
    public string Jogo { get; set; }
    public DateTime Data { get; set; }
    public List<NotaResponse> Notas { get; set; }
}
