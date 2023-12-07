using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Commands.Queries;
using NotasDoJogo.Application.Commands.Request;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("adicionar-nota")]
        public async Task<IActionResult> AdicionarNotaParaJogador([FromBody] NotaRequest request)
        {
            if (request == null)
                return BadRequest("Request inválida");

            var response = await _mediator.Send(request);

            if (!response.Sucesso)
                return BadRequest("Erro ao adicionar Jogador!");

            return Ok(response);
        }

        [HttpGet("visualizar-nota/{id}")]
        public async Task<IActionResult> BuscarNotaById(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new ObterItemQuery<NotaResponse>(id));

            if (!response.Sucesso)
                return NotFound("Nota não encontrada!");

            return Ok(response);
        }

        [HttpGet("notas-jogador/{jogadorId}/partida/{partidaId}")]
        public async Task<IActionResult> BuscarNotasDoJogadorPorPartida(int jogadorId, int partidaId)
        {
            var request = new NotaJogadorPorPartidaRequest
            {
                JogadorId = jogadorId,
                PartidaId = partidaId
            };
            
            var response = await _mediator.Send(request);
            if(response == null) return NotFound("Nenhum jogador ou partida encontrada!");

            return Ok(response);
            
        }

        [HttpGet("media-jogador/{jogadorId}/partida/{partidaId}")]
        public async Task<IActionResult> CalcularMediaDeJogadorPorPartida(int jogadorId, int partidaId)
        {
            var request = new MediaJogadorPorPartidaRequest
            {
                JogadorId = jogadorId,
                PartidaId = partidaId
            };

            var response = await _mediator.Send(request);

            var result = new
            {
                JogadorNome = response.NomeJogador,
                Media = response.Media
            };

            return Ok(result);
        }

        [HttpGet("notas-usuario/{usuarioId}")]
        public async Task<IActionResult> BuscarNotasDoUsuario(int usuarioId)
        {
            if (usuarioId <= 0)
                return BadRequest("Id inválido");

            var request = new NotasDoUsuarioRequest
            {
                UsuarioId = usuarioId
            };

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("nota-media-partida/{partidaId}")]
        public async Task<IActionResult> CalcularMediaByPartidaId(int partidaId)
        {
            if (partidaId <= 0) 
                return BadRequest("Id inválido");

            var request = new NotaMediaDaPartidaRequest
            {
                PartidaId = partidaId
            };

            var response = await _mediator.Send(request);

            var result = new
            {
                Partida = response.Jogo,
                Media = response.Media
            };

            return Ok(result);           
        }

        

        [HttpDelete("deletar-nota/{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var response = await _mediator.Send(new DeletarItemQuery<NotaResponse>(id));

            if (!response.Sucesso)
                return NotFound("Nota não encontrada!");

            return Ok(response.Mensagem = "Nota deletada com Sucesso!");
        }
    }
}