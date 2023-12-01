using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;
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

        public async Task<List<PartidaResponse>> GetPartidasAsync()
        {
            var partidas = await _context.Partidas.ToListAsync();
            var response = _mapper.Map<List<PartidaResponse>>(partidas);

            return response;
        }

        public async Task<PartidaResponse> GetPartidaByIdAsync(int partidaId)
        {
            var partida = await _context.Partidas.FindAsync(partidaId);
            var response = _mapper.Map<PartidaResponse>(partida);
            return response;
        }

        public async Task<PartidaResponse> EditarPartidaAsync(int id, PartidaRequest request)
        {
            var partidaRetorno = await _context.Partidas.FindAsync(id);

            if (partidaRetorno == null)
                return new PartidaResponse() { Sucesso = false };

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

        public async Task<PartidaResponse> DeletePartidaAsync(int partidaId)
        {
            var response = await _context.Partidas.FindAsync(partidaId)
                ?? throw new Exception("Partida para delete não encontrada.");

            _geralPersist.Delete(response);

            await _geralPersist.SaveChangesAsync();

            return _mapper.Map<PartidaResponse>(response);
        }        
    }
}