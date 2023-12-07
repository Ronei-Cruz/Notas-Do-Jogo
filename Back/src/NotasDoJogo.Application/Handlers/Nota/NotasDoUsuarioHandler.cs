using MediatR;
using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Nota
{
    public class NotasDoUsuarioHandler :IRequestHandler<NotasDoUsuarioRequest, List<NotaResponse>>
    {
        private readonly INotaService _service;

        public NotasDoUsuarioHandler(INotaService service)
        {
            _service = service;
        }

        public async Task<List<NotaResponse>> Handle(NotasDoUsuarioRequest request, CancellationToken cancellationToken)
        {
            var response = await _service.NotasDoUsuarioAsync(request.UsuarioId);
            return response;
        }
    }
}
