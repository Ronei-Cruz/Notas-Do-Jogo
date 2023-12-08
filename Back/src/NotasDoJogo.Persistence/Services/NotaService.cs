using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Interfaces;

namespace NotasDoJogo.Persistence.Services
{
    public class NotaService : INotaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly NJContext _context;
        private readonly IMapper _mapper;

        public NotaService(IGeralPersist geralPersist, NJContext context, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotaResponse> AdicionarNotaAsync(NotaRequest request)
        {
            try
            {
                var nota = _mapper.Map<Nota>(request);
                _geralPersist.Add(nota);

                var saveChangesResult = await _geralPersist.SaveChangesAsync();
                if (saveChangesResult)
                {
                    var notaRetorno = await _context.Notas.FindAsync(nota.Id);
                    var response = _mapper.Map<NotaResponse>(notaRetorno);
                    return response;
                }
                return new NotaResponse { Sucesso = false };
            }
            catch (Exception ex)
            {
                return new NotaResponse {
                    Sucesso = false, Mensagem = "Erro ao adicionar jogador. Detalhes: " + ex.Message };
            }
        }

        public async Task<NotaResponse> BuscarNotaPorIdAsync(int partidaId)
        {
            try
            {
                var nota = await _context.Notas
                    .Include(n => n.Jogador)
                    .Include(n => n.Usuario)
                    .Include(n => n.Partida)
                    .FirstOrDefaultAsync(n => n.Id == partidaId);

                if (nota == null) return new NotaResponse() { Sucesso = false };

                var response = _mapper.Map<NotaResponse>(nota);
                return response;
            }
            catch (Exception ex)
            {
                return new NotaResponse {
                    Sucesso = false, Mensagem = "Erro ao visualzar notas por Id. Detalhes: " + ex.Message };
            }

        }
       /* public async Task<List<NotaResponse>> GetNotasAsync()
        {
            var notaRetorno = await _notaPersist.GetAllAsync();
            return _mapper.Map<List<NotaResponse>>(notaRetorno);
        }*/

        public async Task<List<NotaResponse>> BuscarNotasDoJogadorPorPartidaAsync(int jogadorId, int partidaId)
        {
            try
            {
                var notas = await _context.Notas
                    .Include(n => n.Jogador)
                    .Include(n => n.Usuario)
                    .Include(n => n.Partida)
                    .Where(n => n.JogadorId == jogadorId && n.PartidaId == partidaId).ToListAsync();

                if (notas.Count == 0) return null;

                return _mapper.Map<List<NotaResponse>>(notas);
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Erro ao Buscar notas do jogador!: ", ex);
            }
        }

        public async Task<NotaResponse> MediaJogadorPorPartidaAsync(int jogadorId, int partidaId)
        {
            try
            {
                var notas = await _context.Notas
                    .Include(n => n.Jogador)
                    .Include(n => n.Usuario)
                    .Include(n => n.Partida)
                    .Where(n => n.JogadorId == jogadorId && n.PartidaId == partidaId).ToListAsync();

                var response = _mapper.Map<List<NotaResponse>>(notas);

                if (response.Count > 0)
                {
                    var nomeJogador = response.First();
                    decimal somaNotas = response.Sum(n => n.Valor);
                    decimal media = somaNotas / response.Count;
                    return new NotaResponse { Media = Math.Round(media, 1), NomeJogador = nomeJogador.NomeJogador };
                }
                
                return new NotaResponse { Media = 0 };
                
            }
            catch (Exception ex)
            {
                return new NotaResponse {
                    Sucesso = false, Mensagem = "Erro ao visualzar média do jogador. Detalhes: " + ex.Message };
            }
        }

        public async Task<List<NotaResponse>> NotasDoUsuarioAsync(int usuarioId)
        {
            try
            {
                var notas = await _context.Notas
                    .Include(n => n.Jogador)
                    .Include(n => n.Usuario)
                    .Include(n => n.Partida)
                    .Where(n => n.UsuarioId == usuarioId).ToListAsync();
                if (notas.Count == 0) return null;

                return _mapper.Map<List<NotaResponse>>(notas);
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Erro ao Buscar notas do usuário!: ", ex);
            }
        }        

        public async Task<NotaResponse> BuscarMediaPartidaAsync(int partidaId)
        {
            try
            {
                var partidas = await _context.Notas
                    .Include(n => n.Jogador)
                    .Include(n => n.Usuario)
                    .Include(n => n.Partida)
                    .Where(n => n.PartidaId == partidaId).ToListAsync();

                var response = _mapper.Map<List<NotaResponse>>(partidas);

                if (response.Count > 0)
                {
                    var partida = response.First();
                    decimal somaNotas = response.Sum(n => n.Valor);
                    decimal media = somaNotas / response.Count;
                    return new NotaResponse { Media = Math.Round(media, 1), Jogo = partida.Jogo };
                }
                return new NotaResponse { Media = 0 };
            }
            catch (Exception ex)
            {
                return new NotaResponse {
                    Sucesso = false, Mensagem = "Erro ao visualzar média da partida. Detalhes: " + ex.Message };
            }
        }

        public async Task<NotaResponse> DeleteNotaAsync(int id)
        {
            try
            {
                var response = await _context.Notas.FindAsync(id);

                if (response == null) return new NotaResponse() { Sucesso = false };

                _geralPersist.Delete(response);

                await _geralPersist.SaveChangesAsync();

                return _mapper.Map<NotaResponse>(response);
            }
            catch (Exception ex)
            {
                return new NotaResponse
                {
                    Sucesso = false,
                    Mensagem = "Erro ao deletar nota. Detalhes: " + ex.Message
                };
            }
        }
    }
}