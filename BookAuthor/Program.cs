using BookAuthor.Controllers;
using BookAuthor.Services;
using BookAuthor.Services.Interfaces;

var authorController = GetAuthorController();
var bookController = GetBookController();

while (true)
{
    ShowMenu();

Operation:
    Console.WriteLine("Seçim et:");
    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Boş ola bilməz");
        goto Operation;
    }

    if (!int.TryParse(input, out int op))
    {
        Console.WriteLine("Format səhvdir");
        goto Operation;
    }

    switch (op)
    {
        // AUTHOR
        case 1:
            authorController.Create();
            break;

        case 2:
            authorController.GetAll();
            break;

        case 3:
            authorController.Delete();
            break;

        case 4:
            authorController.GetById();
            break;

        case 5:
            authorController.Search();
            break;

        case 6:
            authorController.FilterByAddress();
            break;

        case 7:
            authorController.FilterByAge();
            break;

        // BOOK
        case 8:
            bookController.Create();
            break;

        case 9:
            bookController.GetAll();
            break;

        case 10:
            bookController.Delete();
            break;

        case 11:
            bookController.GetById();
            break;

        case 12:
            bookController.SearchByName();
            break;

        case 13:
            bookController.FilterByColor();
            break;

        case 14:
            bookController.FilterByAuthor();
            break;

        default:
            Console.WriteLine("Seçim tapılmadı");
            break;
    }
}

static AuthorController GetAuthorController()
{
    IAuthorService service = new AuthorService();
    return new AuthorController(service);
}

static BookController GetBookController()
{
    IbookService service = new BookService();
    return new BookController(service);
}

static void ShowMenu()
{
    Console.WriteLine(
        "\n===== AUTHOR =====\n" +
        "1-Create Author\n" +
        "2-Get All Author\n" +
        "3-Delete Author\n" +
        "4-Get Author By Id\n" +
        "5-Search Author\n" +
        "6-Filter By Address\n" +
        "7-Filter By Age\n" +

        "\n===== BOOK =====\n" +
        "8-Create Book\n" +
        "9-Get All Book\n" +
        "10-Delete Book\n" +
        "11-Get Book By Id\n" +
        "12-Search Book\n" +
        "13-Filter By Color\n" +
        "14-Filter By Author\n"
    );
}