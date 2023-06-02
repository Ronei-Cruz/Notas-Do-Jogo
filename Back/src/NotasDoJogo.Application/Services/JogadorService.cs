using AutoMapper;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Application.Services
{
    public class JogadorService : IJogadorService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IJogadorPersist _jogadorPersit;
        private readonly IMapper _mapper;

        public JogadorService(IGeralPersist geralPersist, IJogadorPersist jogadorPersit, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _jogadorPersit = jogadorPersit;
            _mapper = mapper;
        }

        public async Task<JogadorDto> AddJogadorAsync(JogadorDto jogador)
        {
            var model = _mapper.Map<Jogador>(jogador);
            _geralPersist.Add(model);
            var saveChangesResult = await _geralPersist.SaveChangesAsync();

            if (saveChangesResult)
            {
                var jogadorRetorno = await _jogadorPersit.GetByIdAsync(model.Id);
                return _mapper.Map<JogadorDto>(jogadorRetorno);
            }
            return null;
        }

        public async Task<JogadorDto> GetJogadorByIdAsync(int jogadorId)
        {
            var jogadorRetorno = await _jogadorPersit.GetByIdAsync(jogadorId);
            return _mapper.Map<JogadorDto>(jogadorRetorno);
        }

        public async Task<List<JogadorDto>> GetJogadoresAsync()
        {
            var jogadorRetorno = await _jogadorPersit.GetAllAsync();
            return _mapper.Map<List<JogadorDto>>(jogadorRetorno);
        }

        public async Task<JogadorDto> UpdateJogadorAsync(int id, JogadorDto jogador)
        {
            var model = await _jogadorPersit.GetByIdAsync(id);
            if (jogador == null) return null;

            jogador.Id = model.Id;
            _mapper.Map(jogador, model);

            _geralPersist.Update(model);

            if (await _geralPersist.SaveChangesAsync())
            {
                var jogadorUpdate = await _jogadorPersit.GetByIdAsync(jogador.Id);
                return _mapper.Map<JogadorDto>(jogadorUpdate);
            }
            return null;
        }

        public async Task<bool> DeleteJogadorAsync(int jogadorId)
        {
            var jogador = await _jogadorPersit.GetByIdAsync(jogadorId)
                ?? throw new Exception("Jogador para delete não encontrado.");

            _geralPersist.Delete(jogador);
            return await _geralPersist.SaveChangesAsync();
        }  
    }
}