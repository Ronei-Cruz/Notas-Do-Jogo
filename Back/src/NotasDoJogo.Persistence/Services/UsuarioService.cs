using AutoMapper;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence.Services
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

        public async Task<UsuarioDto> AddUsuarioAsync(UsuarioDto usuario)
        {
            var model = _mapper.Map<Usuario>(usuario);

            _geralPersist.Add(model);
            var saveChangesResult = await _geralPersist.SaveChangesAsync();
            
            if (saveChangesResult)
            {
                var usuarioRetorno = await _usuarioPersit.GetByIdAsync(model.Id);
                return _mapper.Map<UsuarioDto>(usuarioRetorno);
            }
            return null;
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int usuarioId)
        {
            var usuarioRetorno = await _usuarioPersit.GetByIdAsync(usuarioId);
            return _mapper.Map<UsuarioDto>(usuarioRetorno);
        }

        public async Task<List<UsuarioDto>> GetUsuariosAsync()
        {
            var usuarioRetorno = await _usuarioPersit.GetAllAsync();
            return _mapper.Map<List<UsuarioDto>>(usuarioRetorno);
        }

        public async Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioDto usuario)
        {
            var model = await _usuarioPersit.GetByIdAsync(id);
            if (model == null) return null;

            usuario.Id = model.Id;
            _mapper.Map(usuario, model);

            _geralPersist.Update(model);
            
            if (await _geralPersist.SaveChangesAsync())
            {
                var usuarioUpdate = await _usuarioPersit.GetByIdAsync(model.Id);
                return _mapper.Map<UsuarioDto>(usuarioUpdate);
            }
            return null;
        }

        public async Task<bool> DeleteUsuarioAsync(int usuarioId)
        {
            var usuario = await _usuarioPersit.GetByIdAsync(usuarioId) 
                ?? throw new Exception("Usuário para delete não encontrado.");

            _geralPersist.Delete(usuario);
            return await _geralPersist.SaveChangesAsync();
        } 
    }
}