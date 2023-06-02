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

        public async Task<PartidaDto> AddPartidaAsync(PartidaDto partida)
        {
            var model = _mapper.Map<Partida>(partida);

            _geralPersist.Add(model);
            var saveChangesResult = await _geralPersist.SaveChangesAsync();

            if(saveChangesResult)
            {
                var partidaRetorno = await _partidaPersist.GetByIdAsync(model.Id);
                return _mapper.Map<PartidaDto>(partidaRetorno);
            }
            return null;
        }

        public async Task<PartidaDto> GetPartidaByIdAsync(int partidaId)
        {
            var partidaRetorno = await _partidaPersist.GetByIdAsync(partidaId);
            return _mapper.Map<PartidaDto>(partidaRetorno);
        }

        public async Task<List<PartidaDto>> GetPartidasAsync()
        {
            var partidaRetorno = await _partidaPersist.GetAllAsync();
            return _mapper.Map<List<PartidaDto>>(partidaRetorno);
        }

        public async Task<PartidaDto> UpdatePartidaAsync(int id, PartidaDto partida)
        {
            var model = await _partidaPersist.GetByIdAsync(id);
            if(model == null) return null;

            partida.Id = model.Id;
            _mapper.Map(partida, model);

            _geralPersist.Update(model);

            if (await _geralPersist.SaveChangesAsync())
            {
                var partidaUpdate = await _partidaPersist.GetByIdAsync(model.Id);
                return _mapper.Map<PartidaDto>(partidaUpdate);
            }
            return null;
        }

        public async Task<bool> DeletePartidaAsync(int partidaId)
        {
            var partida = await _partidaPersist.GetByIdAsync(partidaId) 
                ?? throw new Exception("Partida para delete não encontrada,");
                
            _geralPersist.Delete(partida);
            return await _geralPersist.SaveChangesAsync();
        }        
    }
}