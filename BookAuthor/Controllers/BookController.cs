using BookAuthor.Data;
using BookAuthor.Models;
using BookAuthor.Services;
using BookAuthor.Services.Interfaces;

namespace BookAuthor.Controllers
{
    public class BookController
    {
        private readonly IbookService _bookService;

        public BookController(IbookService bookservice)
        {
            _bookService = bookservice;
        }
        public void GetAll()
        {
            var books = _bookService.GetAll();

            if (books.Length == 0)
            {
                Console.WriteLine("Heç bir kitab tapılmadı");
                return;
            }

            foreach (var b in books)
            {
                Console.WriteLine($"{b.Id} - {b.Name} - {b.Color} - {b.Author.FullName}");
            }
        }

        public void Create()
        {
            Console.WriteLine("Kitab adını daxil et:");

        Name:
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ad boş ola bilməz");
                goto Name;
            }

            Console.WriteLine("Kitab rəngini daxil et:");

        Color:
            string color = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(color))
            {
                Console.WriteLine("Rəng boş ola bilməz");
                goto Color;
            }

            Console.WriteLine("Müəllif adını daxil et:");

        AuthorName:
            string authorName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(authorName))
            {
                Console.WriteLine("Müəllif adı boş ola bilməz");
                goto AuthorName;
            }

            var author = AppDbContext.authors
                .FirstOrDefault(a => a.FullName.Equals(authorName,
                StringComparison.OrdinalIgnoreCase));

            if (author == null)
            {
                Console.WriteLine("Bu müəllif tapılmadı");
                return;
            }

            _bookService.Create(new Book
            {
                Name = name,
                Color = color,
                Author = author
            });

            Console.WriteLine("Kitab uğurla əlavə olundu");
        }

        public void Delete()
        {
            Console.WriteLine("Kitab ID daxil et:");

        Id:
            string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Daxil edilən boş ola bilməz");
                goto Id;
            }

            if (!int.TryParse(idStr, out int id))
            {
                Console.WriteLine("ID rəqəm olmalıdır");
                goto Id;
            }

            _bookService.Delete(id);

            Console.WriteLine("Kitab silindi");
        }

        public void GetById()
        {
            Console.WriteLine("Kitab ID daxil et:");

        Id:
            string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("ID boş ola bilməz");
                goto Id;
            }

            if (!int.TryParse(idStr, out int id))
            {
                Console.WriteLine("ID rəqəm olmalıdır");
                goto Id;
            }

            var book = _bookService.GetById(id);

            if (book == null)
            {
                Console.WriteLine("Kitab tapılmadı");
                return;
            }

            Console.WriteLine($"{book.Id} - {book.Name} - {book.Color} - {book.Author.FullName}");
        }

        public void SearchByName()
        {
            Console.WriteLine("Axtarmaq istədiyiniz kitab adını daxil edin:");

        Query:
            string query = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Axtarış boş ola bilməz");
                goto Query;
            }

            var results = _bookService.SearchByName(query);

            if (results.Length == 0)
            {
                Console.WriteLine("Heç bir nəticə tapılmadı");
                return;
            }

            foreach (var b in results)
            {
                Console.WriteLine($"{b.Id} - {b.Name}");
            }
        }

        public void FilterByColor()
        {
            Console.WriteLine("Rəng daxil et:");

        Color:
            string color = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(color))
            {
                Console.WriteLine("Rəng boş ola bilməz");
                goto Color;
            }

            var results = _bookService.FilterByColor(color);

            if (results.Length == 0)
            {
                Console.WriteLine("Bu rəngdə kitab tapılmadı");
                return;
            }

            foreach (var b in results)
            {
                Console.WriteLine($"{b.Id} - {b.Name} - {b.Color}");
            }
        }

        public void FilterByAuthor()
        {
            Console.WriteLine("Müəllif adını daxil et:");

        Author:
            string authorName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(authorName))
            {
                Console.WriteLine("Müəllif adı boş ola bilməz");
                goto Author;
            }

            var results = _bookService.FilterByAuthor(authorName);

            if (results.Length == 0)
            {
                Console.WriteLine("Bu müəllifə aid kitab tapılmadı");
                return;
            }

            foreach (var b in results)
            {
                Console.WriteLine($"{b.Id} - {b.Name} - {b.Author.FullName}");
            }
        }
    }
}