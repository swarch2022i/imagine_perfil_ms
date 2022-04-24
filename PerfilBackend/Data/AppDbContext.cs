using Microsoft.EntityFrameworkCore;
using PerfilBackend.Models;

namespace PerfilBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Perfil> Perfiles { get; set; }
    }
}
