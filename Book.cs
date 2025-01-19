using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Book
    {
        public string Title { get; set; }
        public string Auther { get; set; }
        public string Year { get; set; }

        public Book(string title)
        {
            this.Title = title;
        }
        public Book(string title, string auther, string year)
        {
            this.Title = title;
            this.Auther = auther;
            this.Year = year;
        }
    }
}
