namespace BookLibrary.Data
{
    using BookLibray.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookLibraryDbContext : DbContext
    {
        private const string ConnectionString = @"Server=.;Database=BookLibraryDb;Integrated Security=True";
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<BooksBorrower>()
                .HasKey(bb => new
                {
                    bb.BookId,
                    bb.BorrowerId
                });

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Borrowers)
                .WithOne(bo => bo.Book)
                .HasForeignKey(bo => bo.BookId);

            modelBuilder.Entity<Borrower>()
                .HasMany(bo => bo.Books)
                .WithOne(b => b.Borrower)
                .HasForeignKey(b => b.BorrowerId);
        }
    }
}
