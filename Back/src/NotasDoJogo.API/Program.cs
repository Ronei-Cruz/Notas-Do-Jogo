using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Services;
using NotasDoJogo.Persistence;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NJContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddControllers();

// Configure AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IJogadorService, JogadorService>();
builder.Services.AddScoped<IJogadorPersist, JogadorPersist>();
builder.Services.AddScoped<IPartidaService, PartidaService>();
builder.Services.AddScoped<IPartidaPersist, PartidaPersist>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioPersist, UsuarioPersist>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => c.SerializeAsV2 = true);
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
