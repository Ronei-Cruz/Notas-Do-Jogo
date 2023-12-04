using MediatR;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Usuario
{
    public class DeletarPerfilUsuarioHandler : IRequestHandler<DeletarItemQuery<UsuarioResponse>, UsuarioResponse>
    {
        private readonly IUsuarioService _service;

        public DeletarPerfilUsuarioHandler(IUsuarioService service)
        {
            _service = service;
        }

        public async Task<UsuarioResponse> Handle(DeletarItemQuery<UsuarioResponse> request, CancellationToken cancellationToken)
        {
            var response = await _service.DeleteUsuarioAsync(request.Id);
            return response;
        }
    }
}
