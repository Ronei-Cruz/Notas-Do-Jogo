using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Commands.Usuario.Request;
using NotasDoJogo.Application.Commands.Usuario.Response;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("adicionar-usuário")]
        public async Task<IActionResult> AdicionardUsuario([FromBody] UsuarioRequest request)
        {
            if (request == null)
                return BadRequest("Request inválida");

            var response = await _mediator.Send(request);

            if (!response.Sucesso)
                return BadRequest("Erro ao adicionar usuário!");

            return Ok(response);
        }

        [HttpGet("visualizar-usuários")]
        public async Task<IActionResult> VisualizarUsuarios()
        {
            var response = await _mediator.Send(new VisualizarItensQuery<UsuarioResponse>());

            if (response.IsNullOrEmpty())
                return BadRequest("Erro ao visualizar usuários!");

            return Ok(response);
        }

        [HttpGet("perfil-usuário/{id}")]
        public async Task<IActionResult> PerfilUsuarioById(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new ObterItemQuery<UsuarioResponse>(id));

            if (!response.Sucesso)
                return BadRequest("Erro ao visualizar perfil do usuário!");

            return Ok(response);
        }

        [HttpPut("editar-usuario/{id}")]
        public async Task<IActionResult> EditarUsuario(int id, UsuarioRequest request)
        {
            if (id <= 0 || request == null)
                return BadRequest("Request inválida");

            var usuario = new EditarItemQuery<UsuarioRequest, UsuarioResponse>
            {
                Id = id,
                Request = request
            };

            var response = await _mediator.Send(usuario);

            if (!response.Sucesso)
                return BadRequest("Erro ao editar perfil do usuário!");

            return Ok(response);
        }

        [HttpDelete("deletar-usuário/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new DeletarItemQuery<UsuarioResponse>(id));

            if (!response.Sucesso)
                return BadRequest("Erro ao deletar perfil do usuário!");

            return Ok(response.Mensagem = "Usuário deletado com Sucesso!");
        }
    }
}