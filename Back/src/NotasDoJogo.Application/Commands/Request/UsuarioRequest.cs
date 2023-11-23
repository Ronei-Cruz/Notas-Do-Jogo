using MediatR;
using NotasDoJogo.Application.Commands.Response;

namespace NotasDoJogo.Application.Commands.Request;

public class UsuarioRequest : IRequest<UsuarioResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}
