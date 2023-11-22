namespace NotasDoJogo.Application.Commands.Request;

public class PartidaRequest : IRequest<PartidaResponse>
{
    public int Id { get; set; }
    public string Jogo { get; set; }
    public DateTime Data { get; set; }
}
