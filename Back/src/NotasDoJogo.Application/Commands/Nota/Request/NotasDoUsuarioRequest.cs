using MediatR;
using NotasDoJogo.Application.Commands.Nota.Response;

namespace NotasDoJogo.Application.Commands.Nota.Request
{
    public class NotasDoUsuarioRequest : IRequest<List<NotaResponse>>
    {
        public int UsuarioId { get; set; }
    }
}
