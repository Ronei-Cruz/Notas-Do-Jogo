using MediatR;
using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Jogador
{
    public class EditarPerfilJogadorHandler : IRequestHandler<EditarItemQuery<JogadorRequest, JogadorResponse>, JogadorResponse>
    {
        private readonly IJogadorService _service;

        public EditarPerfilJogadorHandler(IJogadorService service)
        {
            _service = service;
        }

        public async Task<JogadorResponse> Handle(EditarItemQuery<JogadorRequest, JogadorResponse> request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _service.EditarJogadorAsync(request.Id, request.Request);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao editar perfil do jogador: ", ex);
            }
        }
    }
}
