
namespace BookAuthor.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Author Author { get; set; }
    }
}
