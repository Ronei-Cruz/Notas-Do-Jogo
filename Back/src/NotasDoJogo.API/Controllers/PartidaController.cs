using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application;
using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Commands.Request;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartidaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("adicionar-partida")]
        public async Task<IActionResult> AdicionarPartida([FromBody] PartidaRequest request)
        {
            if (request == null)
                return BadRequest("Request inválida");

            var response = await _mediator.Send(request);

            if (!response.Sucesso)
                return BadRequest("Erro ao adicionar Partida!");

            return Ok(response);
        }

        [HttpGet("visualizar-partidas")]
        public async Task<IActionResult> VisualizarPartidas()
        {
            var response = await _mediator.Send(new VisualizarItensQuery<PartidaResponse>());

            if (response.IsNullOrEmpty())
                return BadRequest("Erro ao visualizar partidas!");

            return Ok(response);
        }

        [HttpGet("informações-partidas/{id}")]
        public async Task<IActionResult> InformacoesPartidaById(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new ObterItemQuery<PartidaResponse>(id));

            if (!response.Sucesso)
                return BadRequest("Erro ao visualizar informações da partida!");

            return Ok(response);
        }

        [HttpPut("editar-partida/{id}")]
        public async Task<IActionResult> EditarPartida(int id, PartidaRequest request)
        {
            if (id <= 0 || request == null)
                return BadRequest("Request inválida");

            var partida = new EditarItemQuery<PartidaRequest, PartidaResponse>
            {
                Id = id,
                Request = request
            };

            var response = await _mediator.Send(partida);

            if (!response.Sucesso)
                return BadRequest("Erro ao editar informações da partida!");

            return Ok(response);
        }

        [HttpDelete("deletar-partida/{id}")]
        public async Task<IActionResult> DeletePartida(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new DeletarItemQuery<PartidaResponse>(id));

            if (!response.Sucesso)
                return BadRequest("Erro ao deletar partida!");

            return Ok(response.Mensagem = "Partida deletada com Sucesso!");
        }
    }
}