using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Persistence.Repository;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;
using NotasDoJogo.Persistence.Seeders;
using NotasDoJogo.Persistence.Services;
using MediatR;
using NotasDoJogo.Application.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR
    (
        typeof(Program).Assembly,
        typeof(AdicionarJogadorHandler).Assembly,
        typeof(VisualizarJogadoresHandler).Assembly
    );

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NJContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddControllers();
builder.Services.AddCors();

// Configure AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IJogadorService, JogadorService>();
builder.Services.AddScoped<IJogadorPersist, JogadorPersist>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<IPartidaPersist, PartidaPersist>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioPersist, UsuarioPersist>();
builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<INotaPersist, NotaPersist>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<NJContext>();
    var dbSeeder = new DbSeeder();
    if (!dbContext.Jogadores.Any())
    {
        dbSeeder.SeedData(dbContext);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => c.SerializeAsV2 = true);
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(cors => cors.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
);

app.MapControllers();

app.Run();
