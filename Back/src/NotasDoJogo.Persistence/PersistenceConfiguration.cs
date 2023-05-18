using Microsoft.Extensions.Configuration;

namespace NotasDoJogo.Persistence
{
    public static class PersistenceConfiguration
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}