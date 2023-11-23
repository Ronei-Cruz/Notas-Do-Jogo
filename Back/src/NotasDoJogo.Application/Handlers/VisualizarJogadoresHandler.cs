using MediatR;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Commands.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers;

public class VisualizarJogadoresHandler : IRequestHandler<VisualizarJogadoresQuery, List<JogadorResponse>>
{
    private readonly IJogadorService _service;

    public VisualizarJogadoresHandler(IJogadorService service)
    {
        _service = service;
    }

    public async Task<List<JogadorResponse>> Handle(VisualizarJogadoresQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var jogadores = await _service.GetJogadoresAsync();
            return jogadores;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Erro ao lançar a solicitação: ", ex);
        }
    }
}
