using NotasDoJogo.Application.Commands.Nota.Response;
using System.Text.Json.Serialization;

namespace NotasDoJogo.Application.Commands.Usuario.Response;

public class UsuarioResponse : ApiResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public List<NotaResponse> Notas { get; set; }
}
