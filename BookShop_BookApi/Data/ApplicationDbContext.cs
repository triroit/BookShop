using BookShop_BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop_BookApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    id = 1,
                    title = "The Great Gatsby",
                    author = "F. Scott Fitzgerald",
                    description = "A novel set in the Roaring Twenties, exploring themes of wealth, excess, and the American dream.",
                    coverUrl = "https://example.com/greatgatsby.jpg",
                    price = 100,
                    stock = 50,
                    addDate = DateTime.Now,
                    language = "English",
                    genre = "Classic"
                },
                new Book()
                {
                    id = 2,
                    title = "To Kill a Mockingbird",
                    author = "Harper Lee",
                    description = "A novel about the serious issues of rape and racial inequality, told through the eyes of a young girl.",
                    coverUrl = "https://example.com/tokillamockingbird.jpg",
                    price = 300,
                    stock = 30,
                    addDate = DateTime.Now,
                    language = "English",
                    genre = "Classic"
                },
                new Book()
                {
                    id = 3,
                    title = "1984",
                    author = "George Orwell",
                    description = "A dystopian novel set in a totalitarian society under constant surveillance.",
                    coverUrl = "https://example.com/1984.jpg",
                    price = 200,
                    stock = 40,
                    addDate = DateTime.Now,
                    language = "English",
                    genre = "Dystopian"
                },
                new Book()
                {
                    id = 4,
                    title = "Pride and Prejudice",
                    author = "Jane Austen",
                    description = "A romantic novel that also critiques the British landed gentry at the end of the 18th century.",
                    coverUrl = "https://example.com/prideandprejudice.jpg",
                    price = 300,
                    stock = 20,
                    addDate = DateTime.Now,
                    language = "English",
                    genre = "Romance"
                },
                new Book()
                {
                    id = 5,
                    title = "The Catcher in the Rye",
                    author = "J.D. Salinger",
                    description = "A novel about teenage rebellion and angst, narrated by the iconic character Holden Caulfield.",
                    coverUrl = "https://example.com/catcherintherye.jpg",
                    price = 100,
                    stock = 25,
                    addDate = DateTime.Now,
                    language = "English",
                    genre = "Classic"
                });
            }
    }
}
