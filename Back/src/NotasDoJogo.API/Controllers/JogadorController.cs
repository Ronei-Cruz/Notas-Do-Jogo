using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorService _jogadorService;

        public JogadorController(IJogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddJogador([FromBody] JogadorDTO jogadorDTO)
        {
            try
            {
                var jogador = await _jogadorService.AddJogadorAsync(jogadorDTO);
                if (jogador != null)
                {
                    return CreatedAtAction(nameof(GetJogadorById), new { id = jogador.Id }, jogador);
                }
                return BadRequest("Falha ao adicionar o jogador.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJogadores()
        {
            try
            {
                var jogador = await _jogadorService.GetJogadoresAsync();
                if (jogador != null)
                {
                    return Ok(jogador);
                }
                return NotFound("Jogador não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJogadorById(int id)
        {
            try
            {
                var jogador = await _jogadorService.GetJogadorByIdAsync(id);
                if (jogador != null)
                {
                    return Ok(jogador);
                }
                return NotFound("Jogador não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJogador(int id, JogadorDTO model)
        {
            try
            {
                var jogador = await _jogadorService.UpdateJogadorAsync(id, model);
                if (jogador == null) return BadRequest("Erro ao tentar atualizar jogador.");
                return Ok(jogador);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar jogador. Erro {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogador(int id)
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
        }
    }
}