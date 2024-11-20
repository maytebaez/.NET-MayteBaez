using Microsoft.EntityFrameworkCore;

namespace ClientsMicroservice.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/Scripts", "BaseDatos.sql");
            var sql = File.ReadAllText(sqlFilePath);
            context.Database.ExecuteSqlRaw(sql);
        }
    }
}
