using MediatR;
using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers
{
    public class AdicionarJogadorHandler : IRequestHandler<JogadorRequest, JogadorResponse>
    {
        private readonly IJogadorService _service;

        public AdicionarJogadorHandler(IJogadorService service)
        {
            _service = service;
        }

        public async Task<JogadorResponse> Handle(JogadorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _service.AddJogadorAsync(request);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao lançar a solicitação: ", ex);
            }
        }
    }
}