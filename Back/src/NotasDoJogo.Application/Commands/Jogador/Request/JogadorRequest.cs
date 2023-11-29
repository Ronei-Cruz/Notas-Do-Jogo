using MediatR;
using NotasDoJogo.Application.Commands.Jogador.Response;

namespace NotasDoJogo.Application.Commands.Jogador.Request
{
    public class JogadorRequest : IRequest<JogadorResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public string Nacionalidade { get; set; }
        public int NumeroCamisa { get; set; }
        public int Idade { get; set; }
    }
}