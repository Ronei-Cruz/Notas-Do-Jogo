using Microsoft.EntityFrameworkCore;
using NotasDoJogo.Application.Contracts;
using NotasDoJogo.Application.Services;
using NotasDoJogo.Persistence.Repository;
using NotasDoJogo.Persistence.Contexts;
using NotasDoJogo.Persistence.Contracts;
using NotasDoJogo.Persistence.Seeders;

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

app.MapControllers();

app.Run();
