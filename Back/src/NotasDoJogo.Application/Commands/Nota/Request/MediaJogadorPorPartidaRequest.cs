using MediatR;
using NotasDoJogo.Application.Commands.Nota.Response;

namespace NotasDoJogo.Application.Commands.Nota.Request
{
    public class MediaJogadorPorPartidaRequest : IRequest<NotaResponse>
    {
        public int JogadorId { get; set; }
        public int PartidaId { get; set; }
    }
}
