using NotasDoJogo.Application.Commands.Usuario.Request;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> AdicionarUsuarioAsync(UsuarioRequest request);
        Task<UsuarioResponse> GetUsuarioByIdAsync(int usuarioId);
        Task<List<UsuarioResponse>> GetUsuariosAsync();
        Task<UsuarioResponse> EditarUsuarioAsync(int id, UsuarioRequest request);
        Task <UsuarioResponse> DeleteUsuarioAsync(int usuarioId);
    }
}