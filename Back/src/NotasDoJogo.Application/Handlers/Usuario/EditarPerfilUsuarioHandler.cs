using MediatR;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Commands.Usuario.Request;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Usuario
{
    public class EditarPerfilUsuarioHandler : IRequestHandler<EditarItemQuery<UsuarioRequest, UsuarioResponse>, UsuarioResponse>
    {
        private readonly IUsuarioService _service;

        public EditarPerfilUsuarioHandler(IUsuarioService service)
        {
            _service = service;
        }

        public async Task<UsuarioResponse> Handle(EditarItemQuery<UsuarioRequest, UsuarioResponse> request, CancellationToken cancellationToken)
        {
            var response = await _service.EditarUsuarioAsync(request.Id, request.Request);
            return response;
        }
    }
}
