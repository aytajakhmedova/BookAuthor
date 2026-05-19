using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthor.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Author { get; set; }
    }
}
