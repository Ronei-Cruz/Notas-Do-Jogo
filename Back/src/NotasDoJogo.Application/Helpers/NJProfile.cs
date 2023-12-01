using AutoMapper;
using NotasDoJogo.Application.Dtos;
using NotasDoJogo.Domain.Models;
using NotasDoJogo.Application.Commands.Jogador.Request;
using NotasDoJogo.Application.Commands.Jogador.Response;
using NotasDoJogo.Application.Commands.Usuario.Response;
using NotasDoJogo.Application.Commands.Usuario.Request;
using NotasDoJogo.Application.Commands.Partida.Request;
using NotasDoJogo.Application.Commands.Partida.Response;

namespace NotasDoJogo.Application.Helpers
{
    public class NJProfile : Profile
    {
        public NJProfile()
        {
            CreateMap<Jogador, JogadorResponse>();
            CreateMap<JogadorRequest, Jogador>();
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<Partida, PartidaResponse>();
            CreateMap<PartidaRequest, Partida>();
            CreateMap<Nota, NotaDto>();
        }
    }
}