using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class LibraryUser : User
    {
        public LibraryUser(string name)
        {
            this.Name = name;
        }

        public void DisplayBooks(Library library)
        {
            library.Display(true);
        }
        public void BorrowBooks(Library library, Book book, int day)
        {
            library.BorrowedBooks(book, day);
        }
    }
}
