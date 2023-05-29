using AutoMapper;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IUsuarioPersist _usuarioPersit;
        private readonly IMapper _mapper;

        public UsuarioService(IGeralPersist geralPersist, IUsuarioPersist usuarioPersit, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _usuarioPersit = usuarioPersit;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> AddUsuarioAsync(UsuarioDTO model)
        {
            var usuario = _mapper.Map<Usuario>(model);

            try
            {
                _geralPersist.Add<Usuario>(usuario);
                var saveChangesResult = await _geralPersist.SaveChangesAsync();
                
                if (saveChangesResult == true)
                {
                    var usuarioRetorno = await _usuarioPersit.GetByIdAsync(usuario.Id);
                    return _mapper.Map<UsuarioDTO>(usuarioRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> GetUsuarioByIdAsync(int usuarioId)
        {
            try
            {
                var usuarioRetorno = await _usuarioPersit.GetByIdAsync(usuarioId);
                return _mapper.Map<UsuarioDTO>(usuarioRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UsuarioDTO>> GetUsuariosAsync()
        {
            try
            {
                var usuarioRetorno = await _usuarioPersit.GetAllAsync();
                return _mapper.Map<List<UsuarioDTO>>(usuarioRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> UpdateUsuarioAsync(int usuarioId, UsuarioDTO model)
        {
            try
            {
                var usuario = await _usuarioPersit.GetByIdAsync(usuarioId);
                if (usuario == null) return null;

                model.Id = usuario.Id;
                _mapper.Map(model, usuario);

                _geralPersist.Update<Usuario>(usuario);
                
                if (await _geralPersist.SaveChangesAsync())
                {
                    var usuarioUpdate = await _usuarioPersit.GetByIdAsync(usuario.Id);
                    return _mapper.Map<UsuarioDTO>(usuarioUpdate);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUsuarioAsync(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersit.GetByIdAsync(usuarioId);
                if (usuario == null) throw new Exception("Usuário para delete não encontrado.");

                _geralPersist.Delete<Usuario>(usuario);
                return (await _geralPersist.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        
    }
}