using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetUsuarioByIdAsync(int usuarioId);
        Task<List<UsuarioDTO>> GetUsuariosAsync();
        Task<UsuarioDTO> AddUsuarioAsync(UsuarioDTO usuario);
        Task<UsuarioDTO> UpdateUsuarioAsync(int id, UsuarioDTO usuario);
        Task <bool>DeleteUsuarioAsync(int usuarioId);
    }
}