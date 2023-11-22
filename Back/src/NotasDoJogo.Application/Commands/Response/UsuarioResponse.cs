namespace NotasDoJogo.Application.Commands.Response;

public class UsuarioResponse : ApiResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<NotaResponse> Notas { get; set; }
}
