using MediatR;
using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Partida
{
    public class EditarInformacoesPartidaHandler : IRequestHandler<EditarItemQuery<PartidaRequest, PartidaResponse>, PartidaResponse>
    {
        private readonly IPartidaService _service;

        public EditarInformacoesPartidaHandler(IPartidaService service)
        {
            _service = service;
        }

        public async Task<PartidaResponse> Handle(EditarItemQuery<PartidaRequest, PartidaResponse> request, CancellationToken cancellationToken)
        {
            var response = await _service.EditarPartidaAsync(request.Id, request.Request);
            return response;
        }
    }
}
