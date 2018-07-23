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

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

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

            modelBuilder.Entity<Book>()
                .HasMany(b => b.History)
                .WithOne(h => h.Book)
                .HasForeignKey(h => h.BookId);

            modelBuilder.Entity<History>()
                .HasMany(h => h.Books)
                .WithOne(b => b.History)
                .HasForeignKey(b => b.HistoryId);

            modelBuilder.Entity<BookHistory>()
                .HasKey(bh => new
                {
                    bh.BookId,
                    bh.HistoryId
                });

            modelBuilder.Entity<MovieHistory>()
                .HasKey(mh => new
                {
                    mh.MovieId,
                    mh.HistoryId
                });

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Borrowers)
                .WithOne(bo => bo.Movie)
                .HasForeignKey(bo => bo.MovieId);

            modelBuilder.Entity<Borrower>()
                .HasMany(bo => bo.Movies)
                .WithOne(m => m.Borrower)
                .HasForeignKey(m => m.BorrowerId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.History)
                .WithOne(h => h.Movie)
                .HasForeignKey(h => h.MovieId);

            modelBuilder.Entity<History>()
                .HasMany(h => h.Movies)
                .WithOne(m => m.History)
                .HasForeignKey(m => m.HistoryId);

            modelBuilder.Entity<MovieBorrower>()
                .HasKey(mb => new
                {
                    mb.MovieId,
                    mb.BorrowerId
                });
        }
    }
}
