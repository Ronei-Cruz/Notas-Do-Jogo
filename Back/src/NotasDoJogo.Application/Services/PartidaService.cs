using AutoMapper;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Application.Services
{
    public class PartidaService : IPartidaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPartidaPersist _partidaPersist;
        private readonly IMapper _mapper;

        public PartidaService(IGeralPersist geralPersist, IPartidaPersist partidaPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _partidaPersist = partidaPersist;
            _mapper = mapper;
        }

        public async Task<PartidaDTO> AddPartidaAsync(PartidaDTO model)
        {
            var partida = _mapper.Map<Partida>(model);

            try
            {
                _geralPersist.Add<Partida>(partida);
                var saveChangesResult = await _geralPersist.SaveChangesAsync();

                if(saveChangesResult == true)
                {
                    var partidaRetorno = await _partidaPersist.GetByIdAsync(partida.Id);
                    return _mapper.Map<PartidaDTO>(partidaRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartidaDTO> GetPartidaByIdAsync(int partidaId)
        {
            try
            {
                var partidaRetorno = await _partidaPersist.GetByIdAsync(partidaId);
                return _mapper.Map<PartidaDTO>(partidaRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PartidaDTO>> GetPartidasAsync()
        {
            try
            {
                var partidaRetorno = await _partidaPersist.GetAllAsync();
                return _mapper.Map<List<PartidaDTO>>(partidaRetorno);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<PartidaDTO> UpdatePartidaAsync(int partidaId, PartidaDTO model)
        {
            try
            {
                var partida = await _partidaPersist.GetByIdAsync(partidaId);
                if(partida == null) return null;

                model.Id = partida.Id;
                _mapper.Map(model, partida);

                _geralPersist.Update<Partida>(partida);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var partidaUpdate = await _partidaPersist.GetByIdAsync(partida.Id);
                    return _mapper.Map<PartidaDTO>(partidaUpdate);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePartidaAsync(int partidaId)
        {
            try
            {
                var partida = await _partidaPersist.GetByIdAsync(partidaId);
                if(partida == null) throw new Exception("Partida para delete não encontrada,");

                _geralPersist.Delete<Partida>(partida);
                return (await _geralPersist.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}