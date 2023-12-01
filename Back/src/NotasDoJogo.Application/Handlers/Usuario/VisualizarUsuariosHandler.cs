using MediatR;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Usuario
{

    public class VisualizarUsuariosHandler : IRequestHandler<VisualizarItensQuery<UsuarioResponse>, List<UsuarioResponse>>
    {
        private readonly IUsuarioService _service;

        public VisualizarUsuariosHandler(IUsuarioService service)
        {
            _service = service;
        }

        public async Task<List<UsuarioResponse>> Handle(VisualizarItensQuery<UsuarioResponse> request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _service.GetUsuariosAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao visualizar a usuário: ", ex);
            }
        }
    }
}
