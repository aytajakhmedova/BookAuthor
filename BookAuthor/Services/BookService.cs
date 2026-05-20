using BookAuthor.Data;
using BookAuthor.Models;
using BookAuthor.Services.Interfaces;

namespace BookAuthor.Services
{
    public class BookService : IbookService
    {
        public Book[] GetAll()
        {
            return AppDbContext.books;
        }

        public Book GetById(int id)
        {
            return AppDbContext.books
                .FirstOrDefault(b => b.Id == id);
        }

        public Book[] SearchByName(string name)
        {
            return AppDbContext.books
                .Where(b => b.Name.Contains(name,
                StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public Book[] FilterByColor(string color)
        {
            return AppDbContext.books
                .Where(b => b.Color.Contains(color,
                StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public Book[] FilterByAuthor(string authorName)
        {
            return AppDbContext.books
                .Where(b => b.Author.FullName.Equals(authorName,
                StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public void Create(Book book)
        {
            Array.Resize(ref AppDbContext.books,
                AppDbContext.books.Length + 1);

            AppDbContext.books[AppDbContext.books.Length - 1] = book;
        }

     
        public void Delete(int id)
        {
            AppDbContext.authors =
                AppDbContext.authors
                .Where(a => a.Id != id)
                .ToArray();

            AppDbContext.books =
                AppDbContext.books
                .Where(b => b.Author.Id != id)
                .ToArray();
        }
    }
    }