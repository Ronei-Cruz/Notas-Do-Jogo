using MediatR;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers;

public class VisualizarJogadoresHandler : IRequestHandler<VisualizarItensQuery<JogadorResponse>, List<JogadorResponse>>
{
    private readonly IJogadorService _service;

    public VisualizarJogadoresHandler(IJogadorService service)
    {
        _service = service;
    }

    public async Task<List<JogadorResponse>> Handle(VisualizarItensQuery<JogadorResponse> request, CancellationToken cancellationToken)
    {
        try
        {
            var jogadores = await _service.GetJogadoresAsync();
            return jogadores;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao visualizar a jogadores: ", ex);
        }
    }
}
