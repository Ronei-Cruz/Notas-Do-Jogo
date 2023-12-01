using MediatR;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Jogador
{
    public class DeletarPerfilJogadorHandler : IRequestHandler<DeletarItemQuery<JogadorResponse>, JogadorResponse>
    {
        private readonly IJogadorService _service;

        public DeletarPerfilJogadorHandler(IJogadorService service)
        {
            _service = service;
        }

        public async Task<JogadorResponse> Handle(DeletarItemQuery<JogadorResponse> request, CancellationToken cancellationToken)
        {
            try
            {
                var jogador = await _service.DeleteJogadorAsync(request.Id);
                return jogador;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao deletar perfil do jogador: ", ex);
            }
        }
    }
}
