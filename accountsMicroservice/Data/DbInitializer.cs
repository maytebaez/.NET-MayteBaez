using System.IO;
using AccountsMicroservice.Data;
using Microsoft.EntityFrameworkCore;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        var sqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/Scripts", "BaseDatos.sql");
        var sql = File.ReadAllText(sqlFilePath);
        context.Database.ExecuteSqlRaw(sql);
    }
}