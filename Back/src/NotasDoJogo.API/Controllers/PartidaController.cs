using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaService _partidaService;

        public PartidaController(IPartidaService partidaService)
        {
            _partidaService = partidaService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPartida([FromBody] PartidaDto partidaDto)
        {
            try
            {
                var partida = await _partidaService.AddPartidaAsync(partidaDto);
                if (partida != null)
                {
                    return CreatedAtAction(nameof(GetPartidaById), new { id = partida.Id }, partida);
                }
                return BadRequest("Falha ao adiciionar a partida.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPartidas()
        {
            try
            {
                var partida = await _partidaService.GetPartidasAsync();
                if(partida != null) return Ok(partida);

                return NotFound("Partida não encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartidaById(int id)
        {
            try
            {
                var partida = await _partidaService.GetPartidaByIdAsync(id);
                if(partida != null) return Ok(partida);

                return NotFound("Partida não encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartida(int id, PartidaDto model)
        {
            try
            {
                var partida = await _partidaService.UpdatePartidaAsync(id, model);
                if(partida == null) return BadRequest("Erro ao tentar atualizar partida.");
                return Ok(partida);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartida(int id)
        {
            try
            {
                var partida = await _partidaService.GetPartidaByIdAsync(id);
                if(partida == null) return NoContent();

                return await _partidaService.DeletePartidaAsync(id) ? Ok(new { message = "Deletado." }) : throw new Exception("Ocorreu um problema não especifico ao tentar deletar Partida.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}