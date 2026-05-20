using BookAuthor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthor.Services.Interfaces
{
    public interface  IbookService
    {
        Book[] GetAll();

        Book GetById(int id);

        Book[] SearchByName(string search);

        Book[] FilterByColor(string color);

        Book[] FilterByAuthor(string authorName);

        void Create(Book book);

        void Delete(int id);
    }
}
