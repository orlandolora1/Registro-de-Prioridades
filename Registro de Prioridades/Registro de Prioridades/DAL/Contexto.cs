using Microsoft.EntityFrameworkCore;
using Registro_de_Prioridades.Models;
#nullable disable
class Contexto : DbContext
{
    public DbSet<Prioridades> prioridades { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = DATA\Prioridades.db");
    }
}
