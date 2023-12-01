using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<UsuarioResponse>> GetUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            var response = _mapper.Map<List<UsuarioResponse>>(usuarios);

            return response;
        }

        public async Task<UsuarioResponse> GetUsuarioByIdAsync(int usuarioId)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            var response = _mapper.Map<UsuarioResponse>(usuario);
            return response;
        }

        public async Task<UsuarioResponse> EditarUsuarioAsync(int id, UsuarioRequest request)
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

        public async Task<UsuarioResponse> DeleteUsuarioAsync(int usuarioId)
        {
            var response = await _context.Usuarios.FindAsync(usuarioId)
                ?? throw new Exception("Usuário para delete não encontrado.");

            _geralPersist.Delete(response);

            await _geralPersist.SaveChangesAsync();

            return _mapper.Map<UsuarioResponse>(response);
        }
    }
}