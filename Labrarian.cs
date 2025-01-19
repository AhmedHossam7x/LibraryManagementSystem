using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Labrarian : User
    {
        public Labrarian(string name)
        {
            Name = name;
        }

        public void AddBook(Book book, Library library)
        {
            library.Add(book);
        }
        public void RemoveBook(Book book, Library library)
        {
            library.Remove(book);
        }
    }
}
