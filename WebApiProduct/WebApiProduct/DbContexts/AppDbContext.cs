using Microsoft.EntityFrameworkCore;
using WebApiProduct.Models;

namespace WebApiProduct.DbContexts
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //Relacion de Tablas a Usar
        public DbSet<Product> products { get; set; }

        //Configuracin de Conexion (SQL para este caso)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("ProductDB");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
