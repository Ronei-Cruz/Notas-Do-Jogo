using MediatR;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Partida;

public class VisualizarPartidasHandler : IRequestHandler<VisualizarItensQuery<PartidaResponse>, List<PartidaResponse>>
{
    private readonly IPartidaService _service;

    public VisualizarPartidasHandler(IPartidaService service)
    {
        _service = service;
    }

    public async Task<List<PartidaResponse>> Handle(VisualizarItensQuery<PartidaResponse> request, CancellationToken cancellationToken)
    {
        var jogadores = await _service.GetPartidasAsync();
        return jogadores;
    }
}
