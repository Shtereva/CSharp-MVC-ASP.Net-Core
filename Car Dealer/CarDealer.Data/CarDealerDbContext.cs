namespace CarDealer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarDealerDbContext : IdentityDbContext
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<PartCar> PartsCars { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartCar>()
                .HasKey(pc => new
                {
                    pc.PartId,
                    pc.CarId
                });

            builder.Entity<Car>(e =>
            {
                e.HasMany(c => c.Sales)
                    .WithOne(s => s.Car)
                    .HasForeignKey(s => s.CarId);

                e.HasMany(c => c.Parts)
                    .WithOne(p => p.Car)
                    .HasForeignKey(p => p.CarId);

                e.Property(m => m.Make).IsRequired().HasMaxLength(50);
                e.Property(m => m.Model).IsRequired().HasMaxLength(50);
            });

            builder.Entity<Customer>(e =>
            {
                e.HasMany(c => c.Sales)
                    .WithOne(s => s.Customer)
                    .HasForeignKey(s => s.CustomerId);

                e.Property(m => m.Name).IsRequired().HasMaxLength(20);
            });

            builder.Entity<Part>(e =>
            {
                e.HasMany(p => p.Cars)
                    .WithOne(c => c.Part)
                    .HasForeignKey(c => c.PartId);

                e.Property(p => p.Name).IsRequired().HasMaxLength(20);
            });

            builder.Entity<Supplier>(e =>
            {
                e.HasMany(s => s.Parts)
                    .WithOne(p => p.Supplier)
                    .HasForeignKey(p => p.SupplierId);

                e.Property(m => m.Name).IsRequired().HasMaxLength(20);
            });

            base.OnModelCreating(builder);
        }
    }
}
