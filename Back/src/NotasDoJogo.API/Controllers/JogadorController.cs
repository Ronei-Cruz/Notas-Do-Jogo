using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application.Commands.Request;
using MediatR;
using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Queries;

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
            var response = await _mediator.Send(new VisualizarItensQuery<JogadorResponse>());

            if (response == null)
                return NotFound("Nenhum jogador encontrado!");
            
            return Ok(response);
        }

        [HttpGet("perfil-jogador/{id}")]
        public async Task<IActionResult> PerfilJogadorById(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new ObterItemQuery<JogadorResponse>(id));

            if (!response.Sucesso)
                return NotFound("Perfil do jogador não encontrado!");
            
            return Ok(response);
        }

        [HttpPut("editar-jogador/{id}")]
        public async Task<IActionResult> EditarJogador(int id, JogadorRequest request)
        {
            if (id <= 0 || request == null) 
                return BadRequest("Request inválida");

            var jogador = new EditarItemQuery<JogadorRequest, JogadorResponse>
            {
                Id = id,
                Request = request
            };

            var response = await _mediator.Send(jogador);

            if (!response.Sucesso)
                return BadRequest("Erro ao salvar atualização do perfil do jogador!");

            return Ok(response);

        }

       [HttpDelete("deletar-jogador/{id}")]
        public async Task<IActionResult> DeletarJogador(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new DeletarItemQuery<JogadorResponse>(id));

            if (!response.Sucesso)
                return NotFound("Perfil do jogador não encontrado!");

            return Ok(response.Mensagem = "Jogador deletado com Sucesso!");
        }
    }
}