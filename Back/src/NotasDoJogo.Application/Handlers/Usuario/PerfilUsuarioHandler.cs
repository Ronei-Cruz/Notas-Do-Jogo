using MediatR;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Usuario
{
    public class PerfilUsuarioHandler : IRequestHandler<ObterItemQuery<UsuarioResponse>, UsuarioResponse>
    {
        private readonly IUsuarioService _service;

        public PerfilUsuarioHandler(IUsuarioService service)
        {
            _service = service;
        }

        public async Task<UsuarioResponse> Handle(ObterItemQuery<UsuarioResponse> request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _service.GetUsuarioByIdAsync(request.Id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao visualizar perfil do usuário: ", ex);
            }
        }
    }
}
