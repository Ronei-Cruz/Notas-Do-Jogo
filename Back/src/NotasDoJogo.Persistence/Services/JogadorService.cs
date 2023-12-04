using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application;
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
            try
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
                return new JogadorResponse { Sucesso = false };
            }
            catch (Exception ex)
            {
                return new JogadorResponse { 
                    Sucesso = false, Mensagem = "Erro ao adicionar jogador. Detalhes: " + ex.Message };
            }
            
        }

        public async Task<List<JogadorResponse>> GetJogadoresAsync()
        {
            try
            {
                var jogadores = await _context.Jogadores.ToListAsync();

                if (jogadores.IsNullOrEmpty()) return null;

                var response = _mapper.Map<List<JogadorResponse>>(jogadores);

                return response;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao visualizar jogadores!: ", ex);
            }
        }

        public async Task<JogadorResponse> GetJogadorByIdAsync(int id)
        {
            try
            {
                var jogador = await _context.Jogadores.FindAsync(id);
                if (jogador == null) return new JogadorResponse() { Sucesso = false };

                var response = _mapper.Map<JogadorResponse>(jogador);
                return response;
            }
            catch (Exception ex)
            {
                return new JogadorResponse { 
                    Sucesso = false, Mensagem = "Erro ao visualzar perfil jogador. Detalhes: " + ex.Message };
            } 
        }

        public async Task<JogadorResponse> EditarJogadorAsync(int id, JogadorRequest request)
        {   
            try
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
            catch (Exception ex)
            {
                return new JogadorResponse { 
                    Sucesso = false, Mensagem = "Erro ao Atualizar jogador. Detalhes: " + ex.Message };
            }

        }

        public async Task<JogadorResponse> DeleteJogadorAsync(int jogadorId)
        {
            try
            {
                var response = await _context.Jogadores.FindAsync(jogadorId);

                if (response == null) return new JogadorResponse() { Sucesso = false };

                _geralPersist.Delete(response);

                await _geralPersist.SaveChangesAsync();

                return _mapper.Map<JogadorResponse>(response);
            }
            catch (Exception ex)
            {
                return new JogadorResponse { 
                    Sucesso = false, Mensagem = "Erro ao deletar jogador. Detalhes: " + ex.Message };
            }
        } 
    }
}