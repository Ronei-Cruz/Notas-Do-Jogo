using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<NotaDTO> AddNotaAsync(NotaDTO model)
        {
            var nota = _mapper.Map<Nota>(model);

            try
            {
                _geralPersist.Add<Nota>(nota);
                await _geralPersist.SaveChangesAsync();

                var notaRetorno = await _notaPersist.GetByIdAsync(nota.Id);
                return _mapper.Map<NotaDTO>(notaRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NotaDTO> GetNotaByIdAsync(int notaId)
        {
            try
            {
                var notaRetorno = await _notaPersist.GetByIdAsync(notaId);
                return _mapper.Map<NotaDTO>(notaRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<NotaDTO>> GetNotasAsync()
        {
            try
            {
                var notaRetorno = await _notaPersist.GetAllAsync();
                return _mapper.Map<List<NotaDTO>>(notaRetorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<decimal> GetNotaCountByJogadorIdAsync(int jogadorId, int partidaId)
        {
            try
            {
                var notas = await _notaPersist.GetNotasByJogadorIdAsync(jogadorId, partidaId);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<NotaDTO>> GetNotasByJogadorIdAsync(int jogadorId, int partidaId)
        {
            try
            {
                var notas = await _notaPersist.GetNotasByJogadorIdAsync(jogadorId, partidaId);
                return _mapper.Map<List<NotaDTO>>(notas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<NotaDTO>> GetNotasByUsuarioIdAsync(int usuarioId)
        {
            try
            {
                var notas = await _notaPersist.GetNotasByUsuarioIdAsync(usuarioId);
                return _mapper.Map<List<NotaDTO>>(notas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteNotaAsync(int notaId)
        {
            try
            {
                var nota = await _notaPersist.GetByIdAsync(notaId);

                if(nota == null) throw new Exception("Nota para Delete não encotrada.");

                _geralPersist.Delete<Nota>(nota);
                return (await _geralPersist.SaveChangesAsync()); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}