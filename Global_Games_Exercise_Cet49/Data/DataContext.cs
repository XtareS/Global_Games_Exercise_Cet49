
namespace Global_Games_Exercise_Cet49.Data
{
    using Global_Games_Exercise_Cet49.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Newl> Newls { get; set; }

        public DbSet<Registo> Registos { get; set; }

        public DbSet<UserLog> UserLogs { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
