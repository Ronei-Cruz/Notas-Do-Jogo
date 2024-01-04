using MediatR;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Domain.Enum;
using System.Text.Json.Serialization;

namespace NotasDoJogo.Application.Commands.Usuario.Request;

public class UsuarioRequest : IRequest<UsuarioResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    [JsonIgnore]
    public PerfilEnum Perfil { get; set; }
}
