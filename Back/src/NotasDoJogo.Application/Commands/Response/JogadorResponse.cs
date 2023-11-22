namespace NotasDoJogo.Application.Commands.Response
{
    public class JogadorResponse : ApiResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int Idade { get; set; }
        public int NumeroCamisa { get; set; }
        public List<NotaResponse> Notas { get; set; }

    }
}