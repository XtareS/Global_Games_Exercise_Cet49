using Global_Games_Exercise_Cet49.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Global_Games_Exercise_Cet49.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Newl> Newls { get; set; }

        public DbSet<Registo> Registos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
