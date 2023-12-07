using MediatR;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Nota
{
    public class VisualizarNotaPorIdHandler : IRequestHandler<ObterItemQuery<NotaResponse>, NotaResponse>
    {
        private readonly INotaService _service;

        public VisualizarNotaPorIdHandler(INotaService service)
        {
            _service = service;
        }

        public async Task<NotaResponse> Handle(ObterItemQuery<NotaResponse> request, CancellationToken cancellationToken)
        {
            var response = await _service.BuscarNotaPorIdAsync(request.Id);
            return response;
        }
    }
}
