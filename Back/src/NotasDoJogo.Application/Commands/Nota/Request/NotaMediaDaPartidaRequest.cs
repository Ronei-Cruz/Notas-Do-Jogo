using MediatR;
using NotasDoJogo.Application.Commands.Nota.Response;

namespace NotasDoJogo.Application.Commands.Nota.Request
{
    public class NotaMediaDaPartidaRequest : IRequest<NotaResponse>
    {
        public int PartidaId { get; set; }
    }
}
