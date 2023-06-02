using AutoMapper;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Application.Services
{
    public class NotaService : INotaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly INotaPersist _notaPersist;
        private readonly IMapper _mapper;

        public NotaService(IGeralPersist geralPersist, INotaPersist notaPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _notaPersist = notaPersist;
            _mapper = mapper;
        }

        public async Task<NotaDto> AddNotaAsync(NotaDto nota)
        {
            var model = _mapper.Map<Nota>(nota);

            _geralPersist.Add(model);
            await _geralPersist.SaveChangesAsync();

            var notaRetorno = await _notaPersist.GetByIdAsync(model.Id);
            return _mapper.Map<NotaDto>(notaRetorno);
        }

        public async Task<NotaDto> GetNotaByIdAsync(int notaId)
        {
            var notaRetorno = await _notaPersist.GetByIdAsync(notaId);
            return _mapper.Map<NotaDto>(notaRetorno);
        }

        public async Task<List<NotaDto>> GetNotasAsync()
        {
            var notaRetorno = await _notaPersist.GetAllAsync();
            return _mapper.Map<List<NotaDto>>(notaRetorno);
        }

        public async Task<decimal> GetNotaCountByJogadorIdAsync(int jogadorId, int partidaId)
        {
            var notas = await _notaPersist.GetNotasPartidaIdByJogadorIdAsync(jogadorId, partidaId);
            if (notas.Count > 0)
            {
                decimal somaNotas = notas.Sum(n => n.Valor);
                decimal media = somaNotas / notas.Count;
                return Math.Round(media,1);
            }
            else
            {
                return 0;
            }
        }

        public async Task<List<NotaDto>> GetNotasPartidaIdByJogadorIdAsync(int jogadorId, int partidaId)
        {
            var notas = await _notaPersist.GetNotasPartidaIdByJogadorIdAsync(jogadorId, partidaId);
            if(notas.Count == 0) throw new KeyNotFoundException("Jogador ou Partida não existe.");
            return _mapper.Map<List<NotaDto>>(notas);
        }

        public async Task<List<NotaDto>> GetNotasByUsuarioIdAsync(int usuarioId)
        {
            var notas = await _notaPersist.GetNotasByUsuarioIdAsync(usuarioId);
            if(notas.Count == 0) throw new KeyNotFoundException("Usuário não existe.");
            return _mapper.Map<List<NotaDto>>(notas);
        }

        public async Task<bool> DeleteNotaAsync(int notaId)
        {
            var nota = await _notaPersist.GetByIdAsync(notaId) 
                ?? throw new Exception("Nota para Delete não encotrada.");

            _geralPersist.Delete(nota);
            return await _geralPersist.SaveChangesAsync();            
        }

        public async Task<decimal> GetMediaPartidaAsync(int partidaId)
        {
            var partidas = await _notaPersist.GetNotasByPartidaIdAsync(partidaId);
            if (partidas.Count > 0)
            {
                decimal somaNotas = partidas.Sum(n => n.Valor);
                decimal media = somaNotas / partidas.Count;
                return Math.Round(media,1);
            }
            else
            {
                return 0;
            }
        }
    }
}