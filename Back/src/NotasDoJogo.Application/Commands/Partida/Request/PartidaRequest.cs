using MediatR;
using NotasDoJogo.Application.Commands.Partida.Response;
using System.Text.Json.Serialization;

namespace NotasDoJogo.Application.Commands.Partida.Request;

public class PartidaRequest : IRequest<PartidaResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Jogo { get; set; }
    public DateTime Data { get; set; }
}
