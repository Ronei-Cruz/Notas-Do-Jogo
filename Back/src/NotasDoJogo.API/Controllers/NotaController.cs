using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNota([FromBody] NotaDTO notaDTO)
        {
            try
            {
                var nota = await _notaService.AddNotaAsync(notaDTO);
                if(nota != null)
                    return CreatedAtAction(nameof(GetNotaById), new { id = nota.Id }, nota);
                return BadRequest("Falha ao adicionar nota.");
            }   
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotaById(int id)
        {
            try
            {
                var nota = await _notaService.GetNotaByIdAsync(id);
                if(nota != null) return Ok(nota);

                return NotFound("Nota não encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("jogador/{jogadorId}/partida/{partidaId}")]
        public async Task<IActionResult> GetNotasByJogadorId(int jogadorId, int partidaId)
        {
            try
            {
                var notas = await _notaService.GetNotasByJogadorIdAsync(jogadorId, partidaId);
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetNotasByUsuarioId(int usuarioId)
        {
            try
            {
                var notas = await _notaService.GetNotasByUsuarioIdAsync(usuarioId);
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("partida/{partidaId}/media")]
        public async Task<IActionResult> GetMediaByPartidaId(int partidaId)
        {
            try
            {
                var notas = await _notaService.GetMediaPartidaAsync(partidaId);
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("jogador/{jogadorId}/partida/{partidaId}/media")]
        public async Task<IActionResult> GetNotaMediaByJogadorId(int jogadorId, int partidaId)
        {
            try
            {
                var media = await _notaService.GetNotaCountByJogadorIdAsync(jogadorId, partidaId);
                return Ok(media);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            try
            {
                var Nota = await _notaService.GetNotaByIdAsync(id);
                if (Nota == null) return NoContent();

                return await _notaService.DeleteNotaAsync(id) ? Ok(new {message = "Deletado."}) :
                    throw new Exception("Ocorreu um problema não especifico ao tentar deletar Nota.");
            }
            catch (Exception ex)
            {
                 return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}