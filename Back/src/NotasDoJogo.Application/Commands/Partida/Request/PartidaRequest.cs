using MediatR;
using NotasDoJogo.Application.Commands.Partida.Response;

namespace NotasDoJogo.Application.Commands.Partida.Request;

public class PartidaRequest : IRequest<PartidaResponse>
{
    public int Id { get; set; }
    public string Jogo { get; set; }
    public DateTime Data { get; set; }
}
