using MediatR;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Partida
{
    public class DeletarPartidaHandler : IRequestHandler<DeletarItemQuery<PartidaResponse>, PartidaResponse>
    {
        private readonly IPartidaService _service;

        public DeletarPartidaHandler(IPartidaService service)
        {
            _service = service;
        }

        public async Task<PartidaResponse> Handle(DeletarItemQuery<PartidaResponse> request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _service.DeletePartidaAsync(request.Id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao deletar partida: ", ex);
            }
        }
    }
}
