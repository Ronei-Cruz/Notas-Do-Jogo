using MediatR;
using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Partida
{
    public class AdicionarPartidaHandler : IRequestHandler<PartidaRequest, PartidaResponse>
    {
        private readonly IPartidaService _service;

        public AdicionarPartidaHandler(IPartidaService service)
        {
            _service = service;
        }

        public async Task<PartidaResponse> Handle(PartidaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _service.AddPartidaAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao lançar a solicitação: ", ex);
            }
        }
    }
}