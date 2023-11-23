using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application.Commands.Request;
using NotasDoJogo.Application.Commands.Response;
using NotasDoJogo.Application.Contracts;
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
            var saveChangesResult = await _geralPersist.SaveChangesAsync();

            if (saveChangesResult)
            {
                var jogadorRetorno = await _context.Jogadores.FindAsync(request.Id);
                var response = new JogadorResponse
                {
                    Dados = jogadorRetorno
                };
                return response;
            }
            return new JogadorResponse
            { 
                Sucesso = false, 
                MensagemErro = "Falha ao salvar as alterações no banco de dados."
            };
        }

        public async Task<JogadorResponse> GetJogadorByIdAsync(int jogadorId)
        {
            var jogadorRetorno = await _context.Jogadores.FindAsync(jogadorId);
            return _mapper.Map<JogadorResponse>(jogadorRetorno);
        }

        public async Task<List<JogadorResponse>> GetJogadoresAsync()
        {
            var jogadorRetorno = await _context.Jogadores.ToListAsync();
            return _mapper.Map<List<JogadorResponse>>(jogadorRetorno);
        }

        public async Task<JogadorResponse> UpdateJogadorAsync(int id, JogadorRequest jogador)
        {
            var model = await _context.Jogadores.FindAsync(id);
            if (jogador == null) return null;

            jogador.Id = model.Id;

            _geralPersist.Update(model);

            if (await _geralPersist.SaveChangesAsync())
            {
                var jogadorUpdate = await _context.Jogadores.FindAsync(jogador.Id);
                return _mapper.Map<JogadorResponse>(jogadorUpdate);
            }
            return null;
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