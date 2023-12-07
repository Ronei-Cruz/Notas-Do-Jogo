using MediatR;
using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Nota
{
    public class AdicionarNotaHandler : IRequestHandler<NotaRequest, NotaResponse>
    {
        private readonly INotaService _service;

        public AdicionarNotaHandler(INotaService service)
        {
            _service = service;
        }

        public async Task<NotaResponse> Handle(NotaRequest request, CancellationToken cancellationToken)
        {
            var resultado = await _service.AdicionarNotaAsync(request);
            return resultado;
        }
    }
}
