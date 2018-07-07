namespace FDMC.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CatsDbContext : DbContext
    {
        private const string ConnectionString = @"Server=.;Database=FDMC;Integrated Security=True";

        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
