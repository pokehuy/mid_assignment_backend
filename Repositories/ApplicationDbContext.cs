using mid_assignment_backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }

        public DbSet<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }

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

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Role = "admin"
                },
                new User
                {
                    Id = 2,
                    Username = "user1",
                    Password = "1",
                    Role = "user"
                },
                new User
                {
                    Id = 3,
                    Username = "user2",
                    Password = "2",
                    Role = "user"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Book1",
                    Author = "Author1",
                    CategoryId = 1,
                },
                new Book
                {
                    Id = 2,
                    Title = "Book2",
                    Author = "Author2",
                    CategoryId = 2,
                },
                new Book
                {
                    Id = 3,
                    Title = "Book3",
                    Author = "Author3",
                    CategoryId = 3,
                },
                new Book
                {
                    Id = 4,
                    Title = "Book4",
                    Author = "Author3",
                    CategoryId = 3,
                },
                new Book
                {
                    Id = 5,
                    Title = "Book5",
                    Author = "Author1",
                    CategoryId = 3,
                },
                new Book
                {
                    Id = 6,
                    Title = "Book6",
                    Author = "Author6",
                    CategoryId = 3,
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Category1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Category2"
                },
                new Category
                {
                    Id = 3,
                    Name = "Category3"
                }
            );

            modelBuilder.Entity<BookBorrowingRequest>().HasData(
                new BookBorrowingRequest{
                    Id = 1,
                    RequestByUserId = 3,
                    Date = DateTime.Now,
                    Status = RequestStatus.Waiting,
                    ProcessedByUserId = 1,
                }
            );

            modelBuilder.Entity<BookBorrowingRequestDetails>().HasData(
                new BookBorrowingRequestDetails
                {
                    BookBorrowingRequestId = 1,
                    BookId = 1,
                },
                new BookBorrowingRequestDetails
                {
                    BookBorrowingRequestId = 1,
                    BookId = 2,
                },
                new BookBorrowingRequestDetails
                {
                    BookBorrowingRequestId = 1,
                    BookId = 3,
                }
            );
        }
    }
}