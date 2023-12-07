using NotasDoJogo.Application.Commands.Nota.Request;
using NotasDoJogo.Application.Commands.Nota.Response;

namespace NotasDoJogo.Application.Contracts
{
    public interface INotaService
    {
        Task<NotaResponse> AdicionarNotaAsync(NotaRequest nota);
        Task<NotaResponse> BuscarNotaPorIdAsync(int notaId);
        //Task<List<NotaResponse>> GetNotasAsync();
        Task<List<NotaResponse>> BuscarNotasDoJogadorPorPartidaAsync(int jogadorId, int partidaId);
        Task<NotaResponse> MediaJogadorPorPartidaAsync(int jogadorId, int partidaId);
        Task<List<NotaResponse>> NotasDoUsuarioAsync(int usuarioId);
        Task<NotaResponse> BuscarMediaPartidaAsync(int partidaId);
        Task <NotaResponse>DeleteNotaAsync(int notaId);
    }
}