using BookAuthor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthor.Services.Interfaces
{
    public interface  IAuthorService
    {
        Author[] GetAll();
        Author GetById(int id);
        Author[] SearchByFullName(string name);
        Author[] FilterByAge(int age);
        Author[] FilterByAddress(string address);
        void Create(Author author);
        void Delete(int id);
    }
}
