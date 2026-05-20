using BookAuthor.Models;
using BookAuthor.Services;
using BookAuthor.Services.Interfaces;


namespace BookAuthor.Controllers
{
    public class AuthorController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public void GetAll()
        {
            var authors = _authorService.GetAll();

            if (authors.Length == 0)
            {
                Console.WriteLine("No Author found");
                return;
            }

            foreach (var d in authors)
            {
                Console.WriteLine($"{d.Id} - {d.FullName}");
            }
        }
        public void Create()
        {
            Console.WriteLine("Add author fullname:");

        Name:
            string fullname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Input can't be empty");
                goto Name;
            }

            if (fullname.Any(char.IsDigit))
            {
                Console.WriteLine("Author fullname cannot contain numbers");
                goto Name;
            }

            Console.WriteLine("Enter email:");

        Email:
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email can't be empty");
                goto Email;
            }

            if (!email.Contains("@"))
            {
                Console.WriteLine("Email format is wrong");
                goto Email;
            }

            Console.WriteLine("Enter address:");

        Address:
            string address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Address can't be empty");
                goto Address;
            }

            Console.WriteLine("Enter age:");

        Age:
            string ageStr = Console.ReadLine();

            if (!int.TryParse(ageStr, out int age))
            {
                Console.WriteLine("Age format is wrong");
                goto Age;
            }

            _authorService.Create(new Author
            {
                FullName = fullname,
                Email = email,
                Address = address,
                Age = age
            });

            Console.WriteLine("Author created successfully");
        
        }
        public void Delete()
        {
            Console.WriteLine("Add author id:");


        Id: string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Input can't be empty");
                goto Id;
            }

            bool isCorrectId = int.TryParse(idStr, out int id);

            if (!isCorrectId)
            {
                Console.WriteLine("Input format is wrong");
                goto Id;
            }

            _authorService.Delete(id);

            Console.WriteLine("Author deleted successfully");
        }
        public void GetById()
        {
            Console.WriteLine("Enter author id:");

        ID:
            string idInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idInput))
            {
                Console.WriteLine("Id can't be null");
                goto ID;
            }

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Id must be a number");
                goto ID;
            }

            var author = _authorService.GetById(id);

            if (author == null)
            {
                Console.WriteLine("Author not found");
                goto ID;
            }

            Console.WriteLine($"{author.Id} , {author.FullName} , {author.Address}");
        }
        public void Search()
        {
            Console.WriteLine("Enter search query (author fullname):");

        Query:
            string query = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Query can't be empty");
                goto Query;
            }

            var results = _authorService.SearchByFullName(query);

            if (results == null || results.Length == 0)
            {
                Console.WriteLine("No authors found matching the query");
                return;
            }

            foreach (var item in results)
            {
                Console.WriteLine($"{item.Id} , {item.FullName} ,");
            }

        }
        public void FilterByAddress()
        {
            Console.WriteLine("Enter address:");

        Address:
            string address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Address can't be empty");
                goto Address;
            }

            var results = _authorService.FilterByAddress(address);

            if (results == null || results.Length == 0)
            {
                Console.WriteLine("No authors found");
                return;
            }

            foreach (var item in results)
            {
                Console.WriteLine($"{item.Id} , {item.FullName} , {item.Address} ");
            }
        }
        public void FilterByAge()
        {
            Console.WriteLine("Enter age:");

        Age:
            string ageInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageInput))
            {
                Console.WriteLine("Age can't be empty");
                goto Age;
            }

            if (!int.TryParse(ageInput, out int age))
            {
                Console.WriteLine("Age must be a number");
                goto Age;
            }

            var results = _authorService.FilterByAge(age);

            if (results == null || results.Length == 0)
            {
                Console.WriteLine("No authors found");
                return;
            }

            foreach (var item in results)
            {
                Console.WriteLine($"{item.Id} , {item.FullName} , {item.Age}");
            }
        }
    }
}


