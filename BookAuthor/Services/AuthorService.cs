using BookAuthor.Data;
using BookAuthor.Models;
using BookAuthor.Services.Interfaces;

namespace BookAuthor.Services
{
    public class AuthorService : IAuthorService
    {

        public Author[] GetAll()
        {
            return AppDbContext .authors;
        }

        public Author GetById(int id)
        {
            return AppDbContext.authors.FirstOrDefault(a => a.Id == id);
        }

        public Author[] SearchByFullName(string name)
        {
            return AppDbContext.authors
                .Where(a => a.FullName.Contains(name,StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public Author[] FilterByAge(int age)
        {
            return AppDbContext.authors.Where(a => a.Age == age).ToArray();
        }

        public Author[] FilterByAddress(string address)
        {
            return AppDbContext.authors
                .Where(a => a.Address.ToLower().Contains(address.ToLower()))
                .ToArray();
        }

       
               public void Create(Author author)
        {
            Array.Resize(ref AppDbContext.authors, AppDbContext.authors.Length + 1);
            AppDbContext.authors[AppDbContext.authors.Length - 1] = author;
        }

        

        public void Delete(int id)
        {
            // əvvəl author silinir
            AppDbContext.authors =
                AppDbContext.authors
                .Where(a => a.Id != id)
                .ToArray();

            // sonra ona aid book-lar silinir
            AppDbContext.books =
                AppDbContext.books
                .Where(b => b.Author.Id != id)
                .ToArray();
        }
    }
}