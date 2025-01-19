namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the library system");
            Console.Write("Are you librarian or regular user (L/R): ");
            var userType = Console.ReadLine().ToLower()[0];
            Library library = new Library();
            Book b1;

            DateTime dateTime = DateTime.Now;

            var cu = DateTime.Now;

            if (cu.Date == dateTime.Date)
                Console.WriteLine("done");
            else
                Console.WriteLine("no");

            if (userType == 'l')
            {
                Console.Write("Welcome Librarion, Enter your name: ");
                var librarionName = Console.ReadLine();
                Labrarian labrarian = new Labrarian(librarionName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome: {labrarian.Name}");
                Console.ForegroundColor = ConsoleColor.White;

                while (true)
                {
                    Console.Write("Pls, Choose to Add book (A) / Remove book (R) / Display book (D) / Exit(0): ");
                    var selected = Console.ReadLine().ToLower()[0];
                    switch (selected)
                    {
                        case 'a':
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("Enter Title of book: ");
                            var titel = Console.ReadLine();
                            Console.Write("Enter Auther of book: ");
                            var outher = Console.ReadLine();
                            Console.Write("Enter year of publication book: ");
                            var year = Console.ReadLine();

                            b1 = new Book(titel, outher, year);
                            labrarian.AddBook(b1, library);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 'r':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Enter name of book: ");
                            var name = Console.ReadLine();
                            b1 = new Book(name);
                            labrarian.RemoveBook(b1, library);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 'd':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            library.Display();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '0':
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invaild Selected");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
            }
            else if (userType == 'r')
            {
                Console.Write("Welcome Librarion, Enter your name: ");
                var librarionName = Console.ReadLine();
                LibraryUser libraryUser = new LibraryUser(librarionName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome: {libraryUser.Name}");
                Console.ForegroundColor = ConsoleColor.White;

                while (true)
                {
                    Console.Write("Pls, Display book (D) / Borrowed Book (B) Exit(0): ");
                    var selected = Console.ReadLine().ToLower()[0];
                    switch (selected)
                    {
                        case 'd':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            libraryUser.DisplayBooks(library);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 'b':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Enter book name: ");
                            var name = Console.ReadLine();
                            Console.Write("How day want to borrow: ");
                            var day = int.Parse(Console.ReadLine());
                            b1 = new Book(name);
                            libraryUser.BorrowBooks(library, b1, day);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '0':
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invaild Selected");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invaild input");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
        }
    }
}
