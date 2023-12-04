using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application;
using NotasDoJogo.Application.Commands.Usuario.Request;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly NJContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(IGeralPersist geralPersist,  NJContext context, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> AdicionarUsuarioAsync(UsuarioRequest request)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(request);
                _geralPersist.Add(usuario);

                var saveChangesResult = await _geralPersist.SaveChangesAsync();

                if (saveChangesResult)
                {
                    var usuarioRetorno = await _context.Usuarios.FindAsync(usuario.Id);
                    var response = _mapper.Map<UsuarioResponse>(usuarioRetorno);
                    return response;
                }
                return new UsuarioResponse { Sucesso = false };
            }
            catch (Exception ex)
            {
                return new UsuarioResponse {
                    Sucesso = false, Mensagem = "Erro ao adicionar usuário. Detalhes: " + ex.Message };
            }  
        }

        public async Task<List<UsuarioResponse>> GetUsuariosAsync()
        {
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                if (usuarios.IsNullOrEmpty()) return null;

                var response = _mapper.Map<List<UsuarioResponse>>(usuarios);

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao visualizar usuários!: ", ex);
            }           
        }

        public async Task<UsuarioResponse> GetUsuarioByIdAsync(int usuarioId)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(usuarioId);
                if (usuario == null) return new UsuarioResponse() { Sucesso = false };

                var response = _mapper.Map<UsuarioResponse>(usuario);
                return response;
            }
            catch (Exception ex)
            {
                return new UsuarioResponse{
                    Sucesso = false, Mensagem = "Erro ao visualzar perfil usuário. Detalhes: " + ex.Message };
            }
        }

        public async Task<UsuarioResponse> EditarUsuarioAsync(int id, UsuarioRequest request)
        {
            try
            {
                var usuarioRetorno = await _context.Usuarios.FindAsync(id);

                if (usuarioRetorno == null)
                    return new UsuarioResponse() { Sucesso = false };

                request.Id = usuarioRetorno.Id;
                _mapper.Map(request, usuarioRetorno);

                _geralPersist.Update(usuarioRetorno);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var usuarioUpdate = await _context.Usuarios.FindAsync(request.Id);
                    var response = _mapper.Map<UsuarioResponse>(usuarioUpdate);
                    return response;
                }

                return new UsuarioResponse() { Sucesso = false };
            }
            catch (Exception ex)
            {
                return new UsuarioResponse{
                    Sucesso = false, Mensagem = "Erro ao Atualizar usuário. Detalhes: " + ex.Message };
            }
        }

        public async Task<UsuarioResponse> DeleteUsuarioAsync(int usuarioId)
        {
            try
            {
                var response = await _context.Usuarios.FindAsync(usuarioId);

                if (response == null) return new UsuarioResponse() { Sucesso = false };

                _geralPersist.Delete(response);

                await _geralPersist.SaveChangesAsync();

                return _mapper.Map<UsuarioResponse>(response);
            }
            catch (Exception ex)
            {
                return new UsuarioResponse{
                    Sucesso = false, Mensagem = "Erro ao deletar usuário. Detalhes: " + ex.Message };
            }
        }
    }
}