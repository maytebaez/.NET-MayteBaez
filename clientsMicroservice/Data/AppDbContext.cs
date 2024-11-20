using ClientsMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientsMicroservice.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
       
        public DbSet<Client> Clientes { get; set; }

    }
}