using Microsoft.EntityFrameworkCore;
using Repaso1ERParcial.Entidades;

namespace Repaso1ERParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Colores> Colores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\GestionColores.db");
        }
    }
}
