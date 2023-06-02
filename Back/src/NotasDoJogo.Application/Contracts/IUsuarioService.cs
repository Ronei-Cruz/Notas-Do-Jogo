using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AddUsuarioAsync(UsuarioDto usuario);
        Task<UsuarioDto> GetUsuarioByIdAsync(int usuarioId);
        Task<List<UsuarioDto>> GetUsuariosAsync();
        Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioDto usuario);
        Task <bool>DeleteUsuarioAsync(int usuarioId);
    }
}