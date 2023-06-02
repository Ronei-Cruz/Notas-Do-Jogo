using Microsoft.AspNetCore.Mvc;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = await _usuarioService.AddUsuarioAsync(usuarioDto);
                if (usuario != null)
                    return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);

                return BadRequest("Falha ao adicionar o usuario.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            try
            {
                var usuario = await _usuarioService.GetUsuariosAsync();
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return NotFound("Usuario não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return NotFound("Usuario não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, UsuarioDto model)
        {
            try
            {
                var usuario = await _usuarioService.UpdateUsuarioAsync(id, model);
                if (usuario == null) return BadRequest("Erro ao tentar atualizar usuario.");
                
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar usuario. Erro {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario == null) return NoContent();

                return await _usuarioService.DeleteUsuarioAsync(id) ? Ok(new {message = "Deletado."}) :
                    throw new Exception("Ocorreu um problema não especifico ao tentar deletar Usuario.");
            }
            catch (Exception ex)
            {
                 return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}