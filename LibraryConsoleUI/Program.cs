using System;
using System.Collections.Generic;
using LibraryClassLibrary;

namespace LibraryConsoleUI
{
    class Program
    {
        private static Library MyLibrary = new Library(true); // Create library instance

        // Some headers, just graphical stuff.. sugar.... icing on the cake.
        private static string[] headerMain = new string[]
        {
            "******************************************************************************************************************************************************",
            "*                                                                    The Library                                                                     *",
            "******************************************************************************************************************************************************\n"
        };
        private static string[] headerDelBook = new string[]
        {
            "******************************************************************************************************************************************************",
            "*                                                               Choose book to remove                                                                *",
            "******************************************************************************************************************************************************\n"
        };
        private static string[] headerEnterDetails = new string[]
        {
            "******************************************************************************************************************************************************",
            "*                                                                Enter book details                                                                  *",
            "******************************************************************************************************************************************************\n"
        };

        private static string[] headerBooks = new string[]
        {
            "******************************************************************************************************************************************************",
            "*                                                                Books in the Library                                                                *",
            "******************************************************************************************************************************************************\n"
        };
        private static string[] headerBookTypeSelection = new string[]
        {
            "******************************************************************************************************************************************************",
            "*                                                              Choose book type to add                                                               *",
            "******************************************************************************************************************************************************\n"
        };

        
        // Where the magic starts!!
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // Hide cursor as default
            MainMenu();
        }

        private static void MainMenu()
        {
            // The options to choose between in main menu
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
                int menuSelection = HpHelpers.MenuHandler(mainMenuItems, headerMain);

                // Beware! Unnessecary comments ahead.
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

                    // Remove Book
                    case 4:
                        RemoveBook();
                        break;

                    // Exit application
                    case 5:
                        HpHelpers.ExitApp();
                        break;
                }
                // End of asbsolutely unnessecary comments. (hopefully)
            }
        }

        /// <summary>
        /// Lets user pick a book in the library and remove it from the list in library
        /// Also lets the user give confirmation before the book is removed.
        /// </summary>
        private static void RemoveBook()
        {
            if (MyLibrary.ListAllBooks().Count > 0) // Else error thrown if list is empty
            {
                Book bookToRemove = HpHelpers.MenuHandler(MyLibrary.ListAllBooks(), headerDelBook);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                bool confirmation = HpHelpers.GetBool($"Are you sure you want to remove {bookToRemove.Title} from library? ");
                Console.ResetColor();
                if (confirmation)
                {
                    HpHelpers.PrintHeader(headerDelBook);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(bookToRemove.ToString());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Deleted!!!");
                    Console.ResetColor();
                    MyLibrary.RemoveBook(bookToRemove);
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nDeletion aborted, no worrys! Press ENTER to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            else
            {
                NoBooks();
            }
        }

        /// <summary>
        /// Tell user there is no books in this library. Worthless library!!!!
        /// </summary>
        private static void NoBooks()
        {
            HpHelpers.PrintHeader(headerMain);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No books in list! Press ENTER to go to main menu.");
            Console.ResetColor();
            Console.ReadLine();
        }

        /// <summary>
        /// Takes a search string entered by user and searches through the books in the library and then returns
        /// a list of books that matches the search
        /// </summary>
        private static void SearchLibrary()
        {
            if (MyLibrary.ListAllBooks().Count > 0)
            {
                Console.Clear();
                HpHelpers.PrintHeader(headerMain);

                string searchTerm = HpHelpers.GetString("Enter search term: ");

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
            else
            {
                NoBooks();
            }
        }

        /// <summary>
        /// Returns a list of all books inte the library list
        /// </summary>
        /// <param name="books"></param>
        private static void ListBooks(List<Book> books)
        {
            if (MyLibrary.ListAllBooks().Count > 0)
            {
                int counter = 0; // Every second row in another color - counter

                HpHelpers.PrintHeader(headerBooks);

                string columns = string.Format("{0,-20} {1,-40} {2,-8} {3,-25} {4,-20} {5,-15}", "Author", "| Title", "| Year", "| Publisher", "| ISBN", "| Category");
                Console.ForegroundColor = ConsoleColor.DarkMagenta; // Print column names in magenta color
                System.Console.WriteLine(columns);
                Console.ResetColor();

                foreach (var book in books)
                {
                    if (counter % 2 == 0) // Even numbers in blue color
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
            else
            {
                NoBooks();
            }
        }

        private static void AddBook()
        {
            string[] addBookOptions = new string[] { "Add new Novel", "Add new E-Book", "Add new Non Fiction book" };

            // What kind of book should be added?
            int selection = HpHelpers.MenuHandler(addBookOptions, headerBookTypeSelection);

            Console.CursorVisible = true;
            if (selection == 0)
            {
                MyLibrary.AddBook(CreateNovel());
            }
            else if (selection == 1)
            {
                MyLibrary.AddBook(CreateEBook());
            }
            else if (selection == 2)
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
            while (addMoreBooks)
            {
                AddBook();
                addMoreBooks = HpHelpers.GetBool("Do you want to add more books? ");
            }
        }

        private static Book CreateEBook()
        {
            HpHelpers.PrintHeader(headerEnterDetails);
            string[] bookDetails = getBookInfo();
            var eBook = new EBook(
                bookDetails[0], bookDetails[1], bookDetails[2], bookDetails[3], bookDetails[4],
                HpHelpers.GetInt("Enter the E-Book length in minutes: ")
            );
            return eBook;
        }

        private static Book CreateNovel()
        {
            HpHelpers.PrintHeader(headerEnterDetails);
            string[] bookDetails = getBookInfo();
            var novel = new Novel(
                bookDetails[0], bookDetails[1], bookDetails[2], bookDetails[3], bookDetails[4],
                HpHelpers.GetInt("Enter the number of Pages: ")
            );
            return novel;
        }

        private static Book CreateNonFiction()
        {
            HpHelpers.PrintHeader(headerEnterDetails);
            string[] bookDetails = getBookInfo();
            var nonFiction = new NonFiction(
                bookDetails[0], bookDetails[1], bookDetails[2], bookDetails[3], bookDetails[4],
                HpHelpers.GetInt("Enter the number of Pages: ")
            );
            return nonFiction;
        }

        private static string[] getBookInfo()
        {
            string[] output = new string[]
            {
                HpHelpers.GetString("Enter the Name of the Author: "),
                HpHelpers.GetString("Enter the Title of the Book: "),
                HpHelpers.GetString("Enter the Publisher: "),
                GetYearOfPublishing(),
                HpHelpers.GetString("Enter the ISBN-number: ")
            };
            return output;
        }

        /// <summary>
        /// Getting the year in digits, HpHelpers does the error handling
        /// Method GetInt used so value entered is an integer, even if it is then stored as a string.
        /// </summary>
        /// <returns></returns>
        private static string GetYearOfPublishing()
        {
            string output = "";
            while (output.Length != 4)
            {
                int yearOfPublication = HpHelpers.GetInt("Enter the Year of Publication(4 digits): ");
                output = Convert.ToString(yearOfPublication);
            }

            return output;
        }
    }
}
