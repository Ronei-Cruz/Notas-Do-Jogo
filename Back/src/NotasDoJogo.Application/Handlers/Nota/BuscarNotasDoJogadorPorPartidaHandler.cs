using MediatR;
using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Nota
{
    public class BuscarNotasDoJogadorPorPartidaHandler : IRequestHandler<NotaJogadorPorPartidaRequest, List<NotaResponse>>
    {
        private readonly INotaService _service;

        public BuscarNotasDoJogadorPorPartidaHandler(INotaService service)
        {
            _service = service;
        }

        public async Task<List<NotaResponse>> Handle(NotaJogadorPorPartidaRequest request, CancellationToken cancellationToken)
        {
            var response = await _service.BuscarNotasDoJogadorPorPartidaAsync(request.JogadorId, request.PartidaId);
            return response;
        }
    }
}
