using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.Library.Model;
using Sandbox.Blogging.Model;

namespace Sandbox
{
    public class SandBoxContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public SandBoxContext(DbContextOptions<SandBoxContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.BlogId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>()
                .Property(p => p.PostId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Blogger>()
                .Property(p => p.BloggerId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>()
                .Property(b => b.BookId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Borrowing>()
                .Property(p => p.BorrowingId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>()
                .Property(p => p.AuthorId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Reader>()
                .Property(p => p.ReaderId)
                .ValueGeneratedOnAdd();

            initializeBlogs(modelBuilder);
            initializeLibrary(modelBuilder);
        }

        private void initializeBlogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogger>().HasData(new { BloggerId = 1, NickName = "John Doe" });
            modelBuilder.Entity<Blogger>().HasData(new { BloggerId = 2, NickName = "Jane Doe" });
            modelBuilder.Entity<Blogger>().HasData(new { BloggerId = 3, NickName = "Anonimous" });

            modelBuilder.Entity<Blog>().HasData(new { BlogId = 1, Url = "/news" });
            modelBuilder.Entity<Blog>().HasData(new { BlogId = 2, Url = "/events" });

            modelBuilder.Entity<Post>().HasData(new { PostId = 1, Title = "Hooray", Content = "New web app with vue client", PostedOn = DateTime.Parse("2021-08-10"), BloggerId = 1, BlogId = 1 });
            modelBuilder.Entity<Post>().HasData(new { PostId = 2, Title = "DB create", Content = "EFCore with sql", PostedOn = DateTime.Parse("2021-08-11"), BloggerId = 1, BlogId = 2 });
            modelBuilder.Entity<Post>().HasData(new { PostId = 3, Title = "Congrats!", Content = "Testng of REST api passed successfullyt", PostedOn = DateTime.Parse("2021-08-12"), BloggerId = 2, BlogId = 1 });
        }
        private void initializeLibrary(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 1, FullName = "Marja Tinline" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 2, FullName = "Jermaine Brolechan" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 3, FullName = "Olly Yakebowitch" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 4, FullName = "Pu Long" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 5, FullName = "Celestina Beeching" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 6, FullName = "Abner Hyland" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 7, FullName = "Florenza Wensley" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 8, FullName = "Brocky Greenier" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 9, FullName = "Marlie Whannel" });
            modelBuilder.Entity<Reader>().HasData(new { ReaderId = 10, FullName = "Raoul Swyne" });

            modelBuilder.Entity<Author>().HasData(new { AuthorId = 1, FullName = "J.R.R.Tolkien" });
            modelBuilder.Entity<Author>().HasData(new { AuthorId = 2, FullName = "J.K.Rowling" });
            modelBuilder.Entity<Author>().HasData(new { AuthorId = 3, FullName = "Agatha Christie" });
            modelBuilder.Entity<Author>().HasData(new { AuthorId = 4, FullName = "Lewis Carroll" });
            modelBuilder.Entity<Author>().HasData(new { AuthorId = 5, FullName = "Jules Verne" });

            modelBuilder.Entity<Book>().HasData(new { BookId = 1, Title = "Lord of the Rings : The Fellowship of the Ring", AuthorId = 1, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 2, Title = "Lord of the Rings : The Two Towers", AuthorId = 1, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 3, Title = "Lord of the Rings : The Return of the King", AuthorId = 1, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 4, Title = "Harry Potter and the Sorcerer's Stone", AuthorId = 2, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 5, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 2, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 6, Title = "Harry Potter and the Prisoner of Azkaban", AuthorId = 2, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 7, Title = "Harry Potter and the Goblet of Fire", AuthorId = 2, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 8, Title = "And Then There Were None", AuthorId = 3, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 9, Title = "Alice's Adventures in Wonderland", AuthorId = 4, TotalAmount = 3 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 10, Title = "Twenty Thousand Leagues Under the Sea", AuthorId = 5, TotalAmount = 2 });
            modelBuilder.Entity<Book>().HasData(new { BookId = 11, Title = "In Search of the Castaways", AuthorId = 5, TotalAmount = 2 });

            modelBuilder.Entity<Borrowing>().HasData(new { BorrowingId = 1, ReaderId = 3, BookId = 5, Date = DateTime.Parse("2021-08-10"), Term = 28 });
            modelBuilder.Entity<Borrowing>().HasData(new { BorrowingId = 2, ReaderId = 1, BookId = 1, Date = DateTime.Parse("2021-08-15"), Term = 14 });
            modelBuilder.Entity<Borrowing>().HasData(new { BorrowingId = 3, ReaderId = 2, BookId = 1, Date = DateTime.Parse("2021-08-15"), Term = 14 });
            modelBuilder.Entity<Borrowing>().HasData(new { BorrowingId = 4, ReaderId = 3, BookId = 4, Date = DateTime.Parse("2021-08-15"), Term = 28 });
            modelBuilder.Entity<Borrowing>().HasData(new { BorrowingId = 5, ReaderId = 1, BookId = 2, Date = DateTime.Parse("2021-08-20"), Term = 14 });
            modelBuilder.Entity<Borrowing>().HasData(new { BorrowingId = 6, ReaderId = 2, BookId = 4, Date = DateTime.Parse("2021-08-20"), Term = 14 });

        }
    }
}
