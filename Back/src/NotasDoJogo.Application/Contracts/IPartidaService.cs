using NotasDoJogo.Application.Dtos;

namespace NotasDoJogo.Application.Contracts
{
    public interface IPartidaService
    {
        Task<PartidaDTO> GetPartidaByIdAsync(int partidaId);
        Task<List<PartidaDTO>> GetPartidasAsync();
        Task<PartidaDTO> AddPartidaAsync(PartidaDTO partida);
        Task<PartidaDTO> UpdatePartidaAsync(int id, PartidaDTO partida);
        Task <bool>DeletePartidaAsync(int partidaId);
    }
}