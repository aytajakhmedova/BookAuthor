using BookAuthor.Models;

namespace BookAuthor.Data
{
    public class AppDbContext
    {
        public Book[] GetAllBook()
        {
            Book book1 = new Book
            {
                Id = 1,
                Name = "SQL",
                Color = "Black",
                Author = "Ali"
            };

            Book book2 = new Book
            {
                Id = 2,
                Name = "C#",
                Color = "Blue",
                Author = "Aytac"
            };

            Book[] books = { book1, book2 };
            return books;
        }

        public Author[] GetAllAuthors()
        {
            Author author1 = new Author
            {
                Id = 1,
                FullName = "Ali Aliyev",
                Email = "ali@mail.com",
                Age = 30,
                Address = "Baku"
            };

            Author author2 = new Author
            {
                Id = 2,
                FullName = "Aytac Ehmedova",
                Email = "aytac@mail.com",
                Age = 25,
                Address = "Qazax"
            };

            Author[] authors = { author1, author2 };
            return authors;
        }
    }
}