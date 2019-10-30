using System.Collections.Generic;
using System.Linq;

namespace LibraryClassLibrary
{
    public class Library
    {
        // The list of books in library
        private List<Book> _books = new List<Book>();

        /// <summary>
        /// If addSomeBooks is true the constructor adds some books on initiation
        /// </summary>
        /// <param name="addSomeBooks"></param>
        public Library(bool addSomeBooks)
        {
            if (addSomeBooks)
            {
                this.AddBook(new NonFiction("Smith Ben", "Beginning JSON", "Apress", "2015", "978-1484202036", 324));
                this.AddBook(new NonFiction("Fry Hannah", "Hello World: Being Human in the Age of Algorithms", "W. W. Norton & Company", "2019", "978-0393357363", 256));
                this.AddBook(new NonFiction("Mojang AB, The Official Minecraft Team", "Minecraft: Guide to Survival", "Del Rey", "2020", "978-0593158135", 96));
                this.AddBook(new Novel("Verne Jules", "Twenty Thousand Leagues Under the Sea", "Pierre-Jules Hetzel", "1870", "978-1530436743", 238));
                this.AddBook(new Novel("Verne Jules", "Journey to the Center of the Earth", "CreateSpace Independent Publishing Platform", "2015", "978-1514640609", 146));
                this.AddBook(new Novel("Adams Douglas", "The Hitchhiker's Guide to the Galaxy", "Del Rey", "1995", "978-0345391803", 224));
                this.AddBook(new EBook("Byström Jonas", "Programmering Visual C++ Grunder", "Triangle Connection LLC", "2013", "978-9175310220", 1));
                this.AddBook(new EBook("Spraul V. Anton", "Think Like a Programmer", "NO STARCH PRESS", "2012", "978-1593274566", 1));
                this.AddBook(new EBook("Joshi Bipin", "Beginning SOLID Principles and Design Patterns for ASP.NET Developers", "APress", "2016", "978-1484218471", 1));
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void AddMultipleBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                _books.Add(book);                
            }
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        /// <summary>
        /// Lists all of the books currently in this library instance
        /// </summary>
        /// <returns></returns>
        public List<Book> ListAllBooks()
        {
            var output = new List<Book>();

            // Get the list of books sorted by author name
            var query = from book in _books
                orderby book.Author
                select book;

            foreach (var book in query)
            {
                output.Add(book);                
            }   
                
            return output;
        }

        /// <summary>
        /// Returns a list of Books that matches the search term(string) provided
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Book> SearchLibrary(string searchTerm)
        {
            var output = new List<Book>();
            
            var query = from book in _books
                    where book.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    book.Author.ToLower().Contains(searchTerm.ToLower()) ||
                    book.Publisher.ToLower().Contains(searchTerm.ToLower()) ||
                    book.YearOfPublication.ToLower().Contains(searchTerm.ToLower()) ||
                    book.ISBN.ToLower().Contains(searchTerm.ToLower())
                    orderby book.Author
                    select book;

            // Add search result to output
            foreach (var book in query)
            {
                output.Add(book);                
            }               
            return output;
        }
    }
}