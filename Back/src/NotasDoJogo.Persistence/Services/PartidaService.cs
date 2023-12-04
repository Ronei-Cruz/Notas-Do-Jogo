using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence.Services
{
    public class PartidaService : IPartidaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly NJContext _context;
        private readonly IMapper _mapper;

        public PartidaService(IGeralPersist geralPersist, NJContext context, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PartidaResponse> AddPartidaAsync(PartidaRequest request)
        {
            try
            {
                var partida = _mapper.Map<Partida>(request);
                _geralPersist.Add(partida);

                var saveChangesResult = await _geralPersist.SaveChangesAsync();

                if (saveChangesResult)
                {
                    var partidaRetorno = await _context.Partidas.FindAsync(partida.Id);
                    var response = _mapper.Map<PartidaResponse>(partidaRetorno);
                    return response;
                }
                return new PartidaResponse { Sucesso = false };
            }
            catch (Exception ex)
            {
                return new PartidaResponse {
                    Sucesso = false, Mensagem = "Erro ao adicionar partida. Detalhes: " + ex.Message };
            }
        }

        public async Task<List<PartidaResponse>> GetPartidasAsync()
        {
            try
            {
                var partidas = await _context.Partidas.ToListAsync();
                if (partidas.IsNullOrEmpty()) return null;

                var response = _mapper.Map<List<PartidaResponse>>(partidas);

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro as visualizar partidas!: ", ex);
            }
        }

        public async Task<PartidaResponse> GetPartidaByIdAsync(int partidaId)
        {
            try
            {
                var partida = await _context.Partidas.FindAsync(partidaId);
                if (partida == null) return new PartidaResponse() { Sucesso = false };

                var response = _mapper.Map<PartidaResponse>(partida);
                return response;
            }
            catch(Exception ex) 
            {
                return new PartidaResponse {
                    Sucesso = false, Mensagem = "Erro ao visualzar perfil partida. Detalhes: " + ex.Message };
            }
        }

        public async Task<PartidaResponse> EditarPartidaAsync(int id, PartidaRequest request)
        {
            try
            {
                var partidaRetorno = await _context.Partidas.FindAsync(id);

                if (partidaRetorno == null)  return new PartidaResponse() { Sucesso = false };

                request.Id = partidaRetorno.Id;
                _mapper.Map(request, partidaRetorno);

                _geralPersist.Update(partidaRetorno);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var partidaUpdate = await _context.Partidas.FindAsync(request.Id);
                    var response = _mapper.Map<PartidaResponse>(partidaUpdate);
                    return response;
                }

                return new PartidaResponse() { Sucesso = false };
            }
            catch (Exception ex)
            {
                return new PartidaResponse {
                    Sucesso = false, Mensagem = "Erro ao Atualizar partida. Detalhes: " + ex.Message };
            }
        }

        public async Task<PartidaResponse> DeletePartidaAsync(int partidaId)
        {
            try
            {
                var response = await _context.Partidas.FindAsync(partidaId);

                if (response == null) return new PartidaResponse() { Sucesso = false };

                _geralPersist.Delete(response);

                await _geralPersist.SaveChangesAsync();

                return _mapper.Map<PartidaResponse>(response);
            }
            catch (Exception ex)
            {
                return new PartidaResponse {
                    Sucesso = false, Mensagem = "Erro ao deletar partida. Detalhes: " + ex.Message };
            }
        }        
    }
}