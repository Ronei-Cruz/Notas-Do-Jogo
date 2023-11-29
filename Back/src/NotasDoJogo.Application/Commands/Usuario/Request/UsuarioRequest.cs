using MediatR;
using NotasDoJogo.Application.Commands.Usuario.Response;

namespace NotasDoJogo.Application.Commands.Usuario.Request;

public class UsuarioRequest : IRequest<UsuarioResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}
