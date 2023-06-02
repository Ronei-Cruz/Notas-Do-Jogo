using AutoMapper;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;

namespace NotasDoJogo.Application.Helpers
{
    public class NJProfile : Profile
    {
        public NJProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Jogador, JogadorDto>().ReverseMap();
            CreateMap<Nota, NotaDto>().ReverseMap();
            CreateMap<Partida, PartidaDto>().ReverseMap();
        }
    }
}