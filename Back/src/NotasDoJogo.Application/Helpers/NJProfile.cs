using AutoMapper;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;

namespace NotasDoJogo.Application.Helpers
{
    public class NJProfile : Profile
    {
        public NJProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Jogador, JogadorResponse>();
            CreateMap<JogadorRequest, Jogador>();
            CreateMap<Nota, NotaDto>().ReverseMap();
            CreateMap<Partida, PartidaDto>().ReverseMap();
        }
    }
}