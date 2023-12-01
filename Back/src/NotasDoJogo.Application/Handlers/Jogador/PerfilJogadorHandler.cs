using MediatR;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Jogador
{
    public class PerfilJogadorHandler : IRequestHandler<ObterItemQuery<JogadorResponse>, JogadorResponse>
    {
        private readonly IJogadorService _service;

        public PerfilJogadorHandler(IJogadorService service)
        {
            _service = service;
        }

        public async Task<JogadorResponse> Handle(ObterItemQuery<JogadorResponse> request, CancellationToken cancellationToken)
        {
            try
            {
                var jogador = await _service.GetJogadorByIdAsync(request.Id);
                return jogador;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao visualizar perfil do jogador: ", ex);
            }
        }
    }
}
