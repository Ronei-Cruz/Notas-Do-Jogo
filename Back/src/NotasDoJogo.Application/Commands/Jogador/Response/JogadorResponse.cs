namespace NotasDoJogo.Application.Commands.Jogador.Response
{
    public class JogadorResponse : ApiResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int Idade { get; set; }
        public string Nacionalidade { get; set; }
        public int NumeroCamisa { get; set; }

    }
}