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
        private readonly NJContext _context;
        

        public JogadorService(IGeralPersist geralPersist)
        {
            _geralPersist = geralPersist;
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

        /* public async Task<JogadorDto> GetJogadorByIdAsync(int jogadorId)
        {
            var jogadorRetorno = await _jogadorPersit.GetByIdAsync(jogadorId);
            return _mapper.Map<JogadorDto>(jogadorRetorno);
        }

        public async Task<List<JogadorDto>> GetJogadoresAsync()
        {
            var jogadorRetorno = await _jogadorPersit.GetAllAsync();
            return _mapper.Map<List<JogadorDto>>(jogadorRetorno);
        }

        public async Task<JogadorDto> UpdateJogadorAsync(int id, JogadorDto jogador)
        {
            var model = await _jogadorPersit.GetByIdAsync(id);
            if (jogador == null) return null;

            jogador.Id = model.Id;
            _mapper.Map(jogador, model);

            _geralPersist.Update(model);

            if (await _geralPersist.SaveChangesAsync())
            {
                var jogadorUpdate = await _jogadorPersit.GetByIdAsync(jogador.Id);
                return _mapper.Map<JogadorDto>(jogadorUpdate);
            }
            return null;
        }

        public async Task<bool> DeleteJogadorAsync(int jogadorId)
        {
            var jogador = await _jogadorPersit.GetByIdAsync(jogadorId)
                ?? throw new Exception("Jogador para delete não encontrado.");

            _geralPersist.Delete(jogador);
            return await _geralPersist.SaveChangesAsync();
        }  */ 
    }
}