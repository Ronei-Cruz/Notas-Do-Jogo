using MediatR;
using NotasDoJogo.Application.Commands.Usuario.Request;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Contracts;

namespace NotasDoJogo.Application.Handlers.Usuario
{
    public class AdicionarUsuarioHandler : IRequestHandler<UsuarioRequest, UsuarioResponse>
    {
        private readonly IUsuarioService _service;

        public AdicionarUsuarioHandler(IUsuarioService service)
        {
            _service = service;
        }

        public async Task<UsuarioResponse> Handle(UsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _service.AdicionarUsuarioAsync(request);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao lançar a solicitação: ", ex);
            }
        }
    }
}
