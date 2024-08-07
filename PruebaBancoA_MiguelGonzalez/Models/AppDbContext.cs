using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaBancoA_MiguelGonzalez.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<RCompra> Compras { get; set; }
        public DbSet<Tarjetas> Tarjetas { get; set; }  
    }
}
