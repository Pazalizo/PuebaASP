using Microsoft.EntityFrameworkCore;
using PuebaASP.Models;

namespace PruebaASP.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}

