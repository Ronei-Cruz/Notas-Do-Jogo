using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;

namespace NotasDoJogo.Application.Contracts
{
    public interface IPartidaService
    {
        Task<PartidaResponse> GetPartidaByIdAsync(int partidaId);
        Task<List<PartidaResponse>> GetPartidasAsync();
        Task<PartidaResponse> AddPartidaAsync(PartidaRequest partida);
        Task<PartidaResponse> EditarPartidaAsync(int id, PartidaRequest partida);
        Task <PartidaResponse> DeletePartidaAsync(int partidaId);
    }
}