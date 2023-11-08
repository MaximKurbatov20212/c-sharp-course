using Microsoft.EntityFrameworkCore;

namespace lab4
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ExperimentEntity> Experiments { get; set; } = null!;
        public DbSet<CardEntity> CardEntities { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=lab4.db");
        }
    }
}
