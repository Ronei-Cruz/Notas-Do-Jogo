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

        public async Task<JogadorDTO> GetJogadorByIdAsync(int jogadorId)
        {
            try
            {
                var jogadorRetorno = await _jogadorPersit.GetByIdAsync(jogadorId);
                return _mapper.Map<JogadorDTO>(jogadorRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<JogadorDTO>> GetJogadoresAsync()
        {
            try
            {
                var jogadorRetorno = await _jogadorPersit.GetAllAsync();
                return _mapper.Map<List<JogadorDTO>>(jogadorRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<bool> DeleteJogadorAsync(int jogadorId)
        {
            
            try
            {
                var jogador = await _jogadorPersit.GetByIdAsync(jogadorId);
                if (jogador == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Jogador>(jogador);
                return (await _geralPersist.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        

        public Task UpdateJogadorAsync(JogadorDTO jogador)
        {
            throw new NotImplementedException();
        }
    }
}