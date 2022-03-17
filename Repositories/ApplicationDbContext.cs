using mid_assignment_backend.Entities;
using Microsoft.EntityFrameworkCore;
namespace mid_assignment_backend.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(){ }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        // }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Posts { get; set; }
        public DbSet<Category> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User table
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(p => p.Id);

            //Book table
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Book>().HasKey(p => p.Id);
            modelBuilder.Entity<Book>()
            .HasOne(p => p.Category)
            .WithMany(p => p.Books)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

            //Category table
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().HasKey(p => p.Id);

            //BookBorrowingRequest table
            modelBuilder.Entity<BookBorrowingRequest>().ToTable("BookBorrowingRequest");
            modelBuilder.Entity<BookBorrowingRequest>().HasKey(p => p.Id);
            modelBuilder.Entity<BookBorrowingRequest>()
            .HasOne(p => p.RequestByUser)
            .WithMany(c => c.BookBorrowingRequests)
            .HasForeignKey(p => p.RequestByUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<BookBorrowingRequest>()
            .HasOne(p => p.ProcessedByUser)
            .WithMany(c => c.ProcessedRequests)
            .HasForeignKey(p => p.ProcessedByUserId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

            //BookBorrowingRequestDetails table
            modelBuilder.Entity<BookBorrowingRequestDetails>().ToTable("BookBorrowingRequestDetails");
            modelBuilder.Entity<BookBorrowingRequestDetails>().HasKey(p => new {p.BookBorrowingRequestId, p.BookId});
            modelBuilder.Entity<BookBorrowingRequestDetails>()
            .HasOne(b => b.BookBorrowingRequest)
            .WithMany(b => b.Details)
            .HasForeignKey(b => b.BookBorrowingRequestId)
            .IsRequired();

            modelBuilder.Entity<BookBorrowingRequestDetails>()
            .HasOne(b => b.Book)
            .WithMany(b => b.Details)
            .HasForeignKey(b => b.BookId)
            .IsRequired();
        }
    }
}