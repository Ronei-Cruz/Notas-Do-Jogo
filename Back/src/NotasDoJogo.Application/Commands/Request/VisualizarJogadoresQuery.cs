using MediatR;
using NotasDoJogo.Application.Commands.Response;

namespace NotasDoJogo.Application.Commands.Request;

public class VisualizarJogadoresQuery : IRequest<List<JogadorResponse>>
{
    // Nenhum parâmetro é necessário para esta solicitação
}
