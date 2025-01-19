using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Library
    {
        public void Add(Book book)
        {
            StreamWriter streamWriter = new StreamWriter("books.txt", append: true);
            streamWriter.WriteLine($"{book.Title},{book.Auther},{book.Year}");
            streamWriter.Close();
            Console.WriteLine("Add succesufly");
        }
        public void Remove(Book book)
        {
            if (File.Exists("books.txt"))
            {
                string[] lines = File.ReadAllLines("books.txt");
                StringBuilder sb = new StringBuilder();
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] lineTitle = line.Split(',');
                        if (lineTitle.Length > 0 && !book.Title.Equals(lineTitle[0], StringComparison.OrdinalIgnoreCase))
                            sb.AppendLine(line);
                    }
                }
                File.WriteAllText("books.txt", sb.ToString());
            }
        }
        public void BorrowedBooks(Book book, int day)
        {
            if (File.Exists("books.txt"))
            {
                CheckBorrow();
                string[] lines = File.ReadAllLines("books.txt");
                StringBuilder sb = new StringBuilder();
                var currentDate = DateTime.Now;
                var currentFutuer = currentDate.AddDays(day);

                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] lineTitle = line.Split(',');
                        if (lineTitle.Length > 0 && book.Title.Equals(lineTitle[0], StringComparison.OrdinalIgnoreCase))
                            sb.AppendLine($"{line}:Borrowed for {day} day from {currentDate} and Available in {currentFutuer}");
                        else
                            sb.AppendLine(line);
                    }
                }
                File.WriteAllText("books.txt", sb.ToString());
            }
        }
        public void Display(bool flag = false)
        {
            if (File.Exists("books.txt"))
            {
                var lineAllText = File.ReadAllText("books.txt");
                foreach (var line in lineAllText.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (!flag)
                        {
                            string[] lineTitle = line.Split(',');
                            Console.WriteLine(lineTitle[0]);
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(line);
                            Console.WriteLine(sb);
                        }
                    }
                }
            }
        } 

        private void CheckBorrow()
        {
            if (File.Exists("books.txt"))
            {
                string lines = File.ReadAllText("books.txt");
                StringBuilder sb = new StringBuilder();
                var currentDay = DateTime.Now;

                foreach (var line in lines.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] lineTitle = line.Split('-');

                        if (lineTitle.Length > 1)
                        {
                            if(DateTime.Parse(lineTitle[1]) < currentDay)
                            {
                                var newwLine = line.Split('=');
                                sb.AppendLine(newwLine[0]);
                            }
                        }
                    }
                }
                File.WriteAllText("books.txt", sb.ToString());
            }
        }
    }
}
