using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application.Commands;
using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

namespace NotasDoJogo.Persistence.Services
{
    public class JogadorService : IJogadorService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly NJContext _context;
        

        public JogadorService(IGeralPersist geralPersist, IMapper mapper, NJContext context)
        {
            _geralPersist = geralPersist;
            _mapper = mapper;
            _context = context;
        }

        public async Task<JogadorResponse> AddJogadorAsync(JogadorRequest request)
        {
            var jogador = _mapper.Map<Jogador>(request);
            _geralPersist.Add(jogador);

            var saveChangesResult = await _geralPersist.SaveChangesAsync();

            if (saveChangesResult)
            {
                var jogadorRetorno = await _context.Jogadores.FindAsync(jogador.Id);
                var response = _mapper.Map<JogadorResponse>(jogadorRetorno);
                return response;
            }
            return new JogadorResponse { Sucesso = false } ;
        }

        public async Task<List<JogadorResponse>> GetJogadoresAsync()
        {
            var jogadores = await _context.Jogadores.ToListAsync();
            var response = _mapper.Map<List<JogadorResponse>>(jogadores);

            return response;
        }

        public async Task<JogadorResponse> GetJogadorByIdAsync(int jogadorId)
        {
            var jogador = await _context.Jogadores.FindAsync(jogadorId);
            var response = _mapper.Map<JogadorResponse>(jogador);
            return response;
        }

        public async Task<JogadorResponse> EditarJogadorAsync(int id, JogadorRequest request)
        {            
            var jogadorRetorno = await _context.Jogadores.FindAsync(id);     

            if (jogadorRetorno == null) 
                return new JogadorResponse() { Sucesso = false };       

            request.Id = jogadorRetorno.Id;
            _mapper.Map(request, jogadorRetorno);

            _geralPersist.Update(jogadorRetorno);

            if (await _geralPersist.SaveChangesAsync())
            {
                var jogadorUpdate = await _context.Jogadores.FindAsync(request.Id);
                var response = _mapper.Map<JogadorResponse>(jogadorUpdate);
                return response;
            }

            return new JogadorResponse() { Sucesso = false };
        }

        public async Task<bool> DeleteJogadorAsync(int jogadorId)
        {
            var jogador = await _context.Jogadores.FindAsync(jogadorId)
                ?? throw new Exception("Jogador para delete não encontrado.");

            _geralPersist.Delete(jogador);
            return await _geralPersist.SaveChangesAsync();
        } 
    }
}