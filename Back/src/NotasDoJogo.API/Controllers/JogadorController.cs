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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJogadorById(int id)
        {
            try
            {
                var jogador = await _jogadorService.GetJogadorPorIdAsync(id);
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
    }
}