using MediatR;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Partida
{
    public class InformacoesPartidaHandler : IRequestHandler<ObterItemQuery<PartidaResponse>, PartidaResponse>
    {
        private readonly IPartidaService _service;

        public InformacoesPartidaHandler(IPartidaService service)
        {
            _service = service;
        }

        public async Task<PartidaResponse> Handle(ObterItemQuery<PartidaResponse> request, CancellationToken cancellationToken)
        {
            var response = await _service.GetPartidaByIdAsync(request.Id);
            return response;
        }
    }
}
