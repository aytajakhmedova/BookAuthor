using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthor.Models
{
    public class Author:BaseEntity
    {
    
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
