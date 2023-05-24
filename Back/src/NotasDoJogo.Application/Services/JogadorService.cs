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

        public async Task<JogadorDTO> AddJogadorAsync(JogadorDTO model)
        {
            var jogador = _mapper.Map<Jogador>(model);

            try
            {
                _geralPersist.Add<Jogador>(jogador);
                var saveChangesResult = await _geralPersist.SaveChangesAsync();
                
                if (saveChangesResult == true)
                {
                    var jogadorRetorno = await _jogadorPersit.GetByIdAsync(jogador.Id);
                    return _mapper.Map<JogadorDTO>(jogadorRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<JogadorDTO>> GetJogadoresAsync()
        {
            throw new NotImplementedException();
        }

        public Task CalcularMediaJogadorAsync(int jogadorId)
        {
            throw new NotImplementedException();
        }
        
        public Task DeleteJogadorAsync(int jogadorId)
        {
            throw new NotImplementedException();
        }

        public Task<JogadorDTO> GetJogadorPorIdAsync(int jogadorId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateJogadorAsync(JogadorDTO jogador)
        {
            throw new NotImplementedException();
        }
    }
}