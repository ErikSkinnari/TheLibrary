using System.Collections.Generic;
using System.Linq;

namespace LibraryClassLibrary
{
    public class Library
    {
        // The list of books in library
        private List<Book> _books = new List<Book>();

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