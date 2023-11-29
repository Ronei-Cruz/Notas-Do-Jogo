using MediatR;

namespace NotasDoJogo.Application.Commands.Request;

public class VisualizarItensQuery<T> : IRequest<List<T>>
{
    // Nenhum parâmetro é necessário para esta solicitação
}
