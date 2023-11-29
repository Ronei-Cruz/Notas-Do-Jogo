using MediatR;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Handlers;
using NotasDoJogo.Persistence.Contracts;
using NotasDoJogo.Persistence.Repository;
using NotasDoJogo.Persistence.Services;

namespace NotasDoJogo.API.ConfigDependencies
{
    public static class ServiceExtensions
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            #region MEDIATOR
            services.AddMediatR
            (
                typeof(Program).Assembly,
                typeof(AdicionarJogadorHandler).Assembly, 
                typeof(VisualizarJogadoresHandler).Assembly,
                typeof(PerfilJogadorHandler).Assembly
            );
            #endregion

            #region PERSIST
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IJogadorPersist, JogadorPersist>();
            services.AddScoped<IPartidaPersist, PartidaPersist>();
            services.AddScoped<INotaPersist, NotaPersist>();
            #endregion

            #region SERVICES
            services.AddScoped<IJogadorService, JogadorService>();
            services.AddScoped<IPartidaService, PartidaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioPersist, UsuarioPersist>();
            services.AddScoped<INotaService, NotaService>();
            #endregion
        }
    }
}
