using BookAuthor.Models;
using BookAuthor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthor.Services
{
    public class AuthorService : IauthorService
    {
        private Author[] _authors = [];

        public Author[] GetAll()
        {
            return _authors;
        }

        public Author GetById(int id)
        {
            return _authors.FirstOrDefault(a => a.Id == id);
        }

        public Author[] SearchByFullName(string name)
        {
            return _authors
                .Where(a => a.FullName.ToLower().Contains(name.ToLower()))
                .ToArray();
        }

        public Author[] FilterByAge(int age)
        {
            return _authors.Where(a => a.Age == age).ToArray();
        }

        public Author[] FilterByAddress(string address)
        {
            return _authors
                .Where(a => a.Address.ToLower().Contains(address.ToLower()))
                .ToArray();
        }

        public void Create(Author author)
        {
            Array.Resize(ref _authors, _authors.Length + 1);
            _authors[1] = author;
        }

        public void Delete(int id)
        {
            _authors = _authors.Where(a => a.Id != id).ToArray();
        }
    }
}