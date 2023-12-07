using MediatR;
using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Nota
{
    public class MediaJogadorPorPartidaHandler : IRequestHandler<MediaJogadorPorPartidaRequest, NotaResponse>
    {
        private readonly INotaService _service;

        public MediaJogadorPorPartidaHandler(INotaService service)
        {
            _service = service;
        }

        public async Task<NotaResponse> Handle(MediaJogadorPorPartidaRequest request, CancellationToken cancellationToken)
        {
            var response = await _service.MediaJogadorPorPartidaAsync(request.JogadorId, request.PartidaId);
            return response;
        }
    }
}
