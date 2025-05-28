using Library_ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing;


namespace Library_ManagementSystem.Database
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Librarian> librarians { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        public DbSet<BookRequest> BookRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data for Books
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", ISBN = "9780743273565", Quantity = 5, img_url = "images/Books/the-great-gatsby.jpg" },
                new Book { BookId = 2, Title = "1984", Author = "George Orwell", Genre = "Dystopian", ISBN = "9780451524935", Quantity = 10, img_url = "images/Books/1984.jpg" },
                new Book { BookId = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", ISBN = "9780061120084", Quantity = 8, img_url = "images/Books/to-kill-a-mockingbird.jpg" },
                new Book { BookId = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", ISBN = "9780141439518", Quantity = 3, img_url = "images/Books/pride-and-prejudice.jpg" },
                new Book { BookId = 5, Title = "Moby Dick", Author = "Herman Melville", Genre = "Adventure", ISBN = "9781503280786", Quantity = 7, img_url = "images/Books/moby-dick.jpg" },
            new Book { BookId = 6, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", ISBN = "9780316769488", Quantity = 4, img_url = "images/Books/the-catcher-in-the- rey.jpg" },
                new Book { BookId = 7, Title = "Brave New World", Author = "Aldous Huxley", Genre = "Dystopian", ISBN = "9780060850524", Quantity = 6, img_url = "images/Books/brave-new-world.jpg" },
                new Book { BookId = 8, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Genre = "Philosophy", ISBN = "9780486415871", Quantity = 3, img_url = "images/Books/crime-and-punishment.jpeg" },
                new Book { BookId = 9, Title = "War and Peace", Author = "Leo Tolstoy", Genre = "Historical", ISBN = "9780140447934", Quantity = 5, img_url = "images/Books/war-and-peace.jpg" },
                new Book { BookId = 10, Title = "The Odyssey", Author = "Homer", Genre = "Epic", ISBN = "9780140268867", Quantity = 2, img_url = "images/Books/odysessy.jpg" },
                new Book { BookId = 11, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", ISBN = "9780345339683", Quantity = 9, img_url = "images/Books/the-hobit.jpg" },
                new Book { BookId = 12, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Genre = "Fantasy", ISBN = "9780618640157", Quantity = 10, img_url = "images/Books/the-lord-of-the-rings.jpg" },
                new Book { BookId = 13, Title = "Fahrenheit 451", Author = "Ray Bradbury", Genre = "Dystopian", ISBN = "9781451673319", Quantity = 6, img_url = "images/Books/Fahrenheit451.jpg" },
                new Book { BookId = 14, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", Genre = "Philosophical", ISBN = "9780141439570", Quantity = 4, img_url = "images/Books/the-picture-of-dorian-gray.jpg" }
            );

            modelBuilder.Entity<Librarian>().HasData(
                new Librarian { LibrarianId = 1, Username = "Nitesh Shrestha", Email = "niteshrestha00@gmail.com", PasswordHash = "12345" }
             );
        }
    }
}
