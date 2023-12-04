using NotasDoJogo.Application.Commands.Nota.Response;
using System.Text.Json.Serialization;

namespace NotasDoJogo.Application.Commands.Partida.Response;

public class PartidaResponse : ApiResponse
{
    public int Id { get; set; }
    public string Jogo { get; set; }
    public DateTime Data { get; set; }
    [JsonIgnore]
    public List<NotaResponse> Notas { get; set; }
}
