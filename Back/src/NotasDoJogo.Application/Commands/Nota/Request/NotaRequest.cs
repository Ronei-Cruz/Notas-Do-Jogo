using MediatR;
using NotasDoJogo.Application.Commands.Nota.Response;

namespace NotasDoJogo.Application.Commands.Nota.Request;

public class NotaRequest : IRequest<NotaResponse>
{
    public int Id { get; set; }
    public int JogadorId { get; set; }
    public int UsuarioId { get; set; }
    public int PartidaId { get; set; }
    public int Valor { get; set; }
}
