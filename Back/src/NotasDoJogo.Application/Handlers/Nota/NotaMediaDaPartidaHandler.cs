using MediatR;
using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Nota
{
    public class NotaMediaDaPartidaHandler : IRequestHandler<NotaMediaDaPartidaRequest, NotaResponse>
    {
        private readonly INotaService _service;

        public NotaMediaDaPartidaHandler(INotaService service)
        {
            _service = service;
        }

        public async Task<NotaResponse> Handle(NotaMediaDaPartidaRequest request, CancellationToken cancellationToken)
        {
            var response = await _service.BuscarMediaPartidaAsync(request.PartidaId);
            return response;
        }
    }
}
