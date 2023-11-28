using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application;
using MediatR;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JogadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("adicionar-jogador")]
        public async Task<IActionResult> AdicionarJogador([FromBody] JogadorRequest request)
        {
            if (request == null)
                return BadRequest("Request inválida");

            var response = await _mediator.Send(request);

            if (!response.Sucesso)
                return BadRequest("Erro ao adicionar Jogador!");
            
            return Ok(response);
        }

        [HttpGet("visualizar-jogadores")]
        public async Task<IActionResult> VisualizarJogadores()
        {
            var response = await _mediator.Send(new VisualizarJogadoresQuery ());

            if (response.IsNullOrEmpty())
                return BadRequest("Erro ao visualizar jogadores!");
            
            return Ok(response);
        }

        /* [HttpGet("visualizar-jogador/{id}")]
        public async Task<IActionResult> VisualizarJogadorById(int id)
        {
            if (id == null)
                return BadRequest("Request inválida");

            var response = await _mediator.Send(id);

            if (!response.Sucesso)
                return BadRequest(response.MensagemErro = "Erro ao adicionar Jogador!");
            
            return Ok(response);
        }

        [HttpPut("editar-jogador/{id}")]
        public async Task<IActionResult> EditarJogador(int id, JogadorRequest request)
        {
            try
            {
                var jogador = await _jogadorService.UpdateJogadorAsync(id, jogadorDto);
                if (jogador == null) return BadRequest("Erro ao tentar atualizar jogador.");
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar jogador. Erro {ex.Message}");
            }
        }

        [HttpDelete("deletar-jogador/{id}")]
        public async Task<IActionResult> DeletarJogador(int id)
        {
            try
            {
                var jogador = await _jogadorService.GetJogadorByIdAsync(id);
                if (jogador == null) return NoContent();

                return await _jogadorService.DeleteJogadorAsync(id) ? Ok(new {message = "Deletado."}) :
                    throw new Exception("Ocorreu um problema não especifico ao tentar deletar Jogador.");
            }
            catch (Exception ex)
            {
                 return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        } */
    }
}