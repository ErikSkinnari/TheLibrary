using System;
using System.Collections.Generic;
using LibraryClassLibrary;

namespace LibraryConsoleUI
{
    class Program
    {
        private static Library MyLibrary = new Library();

        
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // Hide cursor as default
            PrepareBookList();
            MainMenu();
        }

        private static void PrepareBookList()
        {
            MyLibrary.AddBook(new NonFiction("Smith Ben", "Beginning JSON", "Apress", "2015", "978-1484202036", 324));
            MyLibrary.AddBook(new NonFiction("Fry Hannah", "Hello World: Being Human in the Age of Algorithms", "W. W. Norton & Company", "2019", "978-0393357363", 256));
            MyLibrary.AddBook(new NonFiction("Mojang AB, The Official Minecraft Team", "Minecraft: Guide to Survival", "Del Rey", "2020", "978-0593158135", 96));
            MyLibrary.AddBook(new Novel("Verne Jules", "Twenty Thousand Leagues Under the Sea", "Pierre-Jules Hetzel", "1870", "978-1530436743", 238));
            MyLibrary.AddBook(new Novel("Verne Jules", "Journey to the Center of the Earth", "CreateSpace Independent Publishing Platform", "2015", "978-1514640609", 146));
            MyLibrary.AddBook(new Novel("Adams Douglas", "The Hitchhiker's Guide to the Galaxy", "Del Rey", "1995", "978-0345391803", 224));
            MyLibrary.AddBook(new EBook("Byström Jonas", "Programmering Visual C++ Grunder", "Triangle Connection LLC", "2013", "978-9175310220", 1));
            MyLibrary.AddBook(new EBook("Spraul V. Anton", "Think Like a Programmer", "NO STARCH PRESS", "2012", "9781593274566", 1));
            MyLibrary.AddBook(new EBook("Joshi Bipin", "Beginning SOLID Principles and Design Patterns for ASP.NET Developers", "APress", "2016", "9781484218471", 1));
        }

        public static void MainMenu() 
        {
            // The options to chose between in main menu
            string[] mainMenuItems = new string[] {
            "Add Book", 
            "Add multiple books", 
            "List/Print all books", 
            "Search in library",
            "Remove Book from Library",
            "Exit Application"
            };

            while (true)
            {
                int menuSelection = HpHelpers.MenuHandler(mainMenuItems);

                switch (menuSelection)
                {
                    // Add Book
                    case 0:
                        AddBook();
                    break;

                    // Add Multiple Books
                    case 1:
                        AddBooks();
                    break;

                    // List/Print all Books
                    case 2:
                        ListBooks(MyLibrary.ListAllBooks());
                    break;

                    // Search in Library
                    case 3:
                        SearchLibrary();
                    break;

                    case 4:
                        RemoveBook();
                    break;

                    // Exit application
                    case 5:
                        HpHelpers.ExitApp();
                    break;
                }
            }
        }

        private static void RemoveBook()
        {
            Console.Clear();
            System.Console.WriteLine("Select Book to remove, Press ENTER to get list of books");
            Console.ReadLine();
            MyLibrary.RemoveBook(HpHelpers.MenuHandler(MyLibrary.ListAllBooks()));
        }

        private static void SearchLibrary()
        {
            Console.Clear();
            System.Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();
            List<Book> searchResult = MyLibrary.SearchLibrary(searchTerm);

            if (searchResult.Count < 1)
            {
                System.Console.WriteLine("No result found. Press ENTER to go back to Main Menu");

                Console.ReadLine();
            }
            else
            {
                ListBooks(searchResult);
            }
        }

        private static void ListBooks(List<Book> books)
        {
            int counter = 0; // Every second row in another color - counter
            Console.Clear();
            System.Console.WriteLine("************************************************************");
            System.Console.WriteLine("*                   Books in the Library                   *");
            System.Console.WriteLine("************************************************************\n");

            string columns = string.Format("{0,-20} {1,-40} {2,-30} {3,-20} {4,-20}", "Author", "| Title", "| Publisher", "| ISBN", "| Category");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; // Print column names in magenta color
            System.Console.WriteLine(columns);
            Console.ResetColor();

            foreach (var book in books)
            {
                if(counter % 2 == 0) // Even numbers in blue color
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine(book.ToString());
                    Console.ResetColor();
                }
                else // Odd numbers in white
                {
                    System.Console.WriteLine(book.ToString());
                }

                counter++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("\nPress ENTER to Go back to main menu");
            Console.ResetColor();
            Console.ReadLine();
        }

        private static void AddBook()
        {
            string[] addBookOptions = new string[] {
            "Add new Novel",
            "Add new E-Book",
            "Add new Short Story",
            "Add new Non Fiction book"
            };
            // What kind of book should be added?
            int selection = HpHelpers.MenuHandler(addBookOptions);

            Console.CursorVisible = true;
            if(selection == 0)
            {
                MyLibrary.AddBook(CreateNovel());
            }
            else if(selection == 1)
            {
                MyLibrary.AddBook(CreateEBook());
            }
            else if(selection == 2)
            {
                MyLibrary.AddBook(CreateShortStory());
            }
            else if(selection == 3)
            {
                MyLibrary.AddBook(CreateNonFiction());
            }
            else
            {
                System.Console.WriteLine("Something went wrong. Press ENTER to go back to Main Menu.");
                Console.ReadLine();
            }
            Console.CursorVisible = false;
        }

        private static void AddBooks()
        {
            bool addMoreBooks = true;

            while(addMoreBooks)
            {
                AddBook();
                addMoreBooks = HpHelpers.GetBool("Do you want to add more books? ");
            }
        }

        public static Book CreateShortStory()
        {
            var shortStory = new ShortStory(
                HpHelpers.GetString("Enter the Name of the Author: "),
                HpHelpers.GetString("Enter the Title of the Book: "),
                HpHelpers.GetString("Enter the Publisher: "),
                GetYearOfPublishing(),
                HpHelpers.GetString("Enter the 13 digit ISBN-number: "),
                HpHelpers.GetInt("Enter the number of Pages: ")
            );
            return shortStory;
        }

        public static Book CreateEBook()
        {
            var eBook = new EBook(
                HpHelpers.GetString("Enter the Name of the Author: "),
                HpHelpers.GetString("Enter the Title of the Book: "),
                HpHelpers.GetString("Enter the Publisher: "),
                GetYearOfPublishing(),
                HpHelpers.GetString("Enter the 13 digit ISBN-number: "),
                HpHelpers.GetInt("Enter the E-Book length in minutes: ")
            );
            return eBook;
        }

        public static Book CreateNovel()
        {
            var novel = new Novel(
                HpHelpers.GetString("Enter the Name of the Author: "),
                HpHelpers.GetString("Enter the Title of the Book: "),
                HpHelpers.GetString("Enter the Publisher: "),
                GetYearOfPublishing(),
                HpHelpers.GetString("Enter the 13 digit ISBN-number: "),
                HpHelpers.GetInt("Enter the number of Pages: ")
            );
            return novel;
        }

        public static Book CreateNonFiction()
        {
            var nonFiction = new NonFiction(
                HpHelpers.GetString("Enter the Name of the Author: "),
                HpHelpers.GetString("Enter the Title of the Book: "),
                HpHelpers.GetString("Enter the Publisher: "),
                GetYearOfPublishing(),
                HpHelpers.GetString("Enter the 13 digit ISBN-number: "),
                HpHelpers.GetInt("Enter the number of Pages: ")
            );
            return nonFiction;
        }

        static string GetYearOfPublishing()
        {
            string output;

            // Getting the year in digits, HpHelpers does the error handling
            // Method GetInt used so value entered is an integer, even if it is then stored as a string.
            int yearOfPublication = HpHelpers.GetInt("Enter the Year of Publication(4 digits): ");

            output = Convert.ToString(yearOfPublication);

            return output;
        }
    }
}
