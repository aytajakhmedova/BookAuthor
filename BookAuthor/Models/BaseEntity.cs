

namespace BookAuthor.Models
{
    public class BaseEntity
    {
        private static int _id;

        public int Id { get; set; }

        public BaseEntity()
        {
            _id++;
            Id = _id;
        }
    }
}
