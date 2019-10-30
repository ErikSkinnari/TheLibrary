namespace LibraryClassLibrary
{
    public class Novel : Book
    {
        public int Pages { get; set; }

        public Novel(string author, string title, string publisher, string yearOfPublication, string isbn, int pages)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            YearOfPublication = yearOfPublication;
            ISBN = isbn;
            Pages = pages;
        }

        public override string ToString()
        {
            string output;

            string author = Author.FormatStringLength(20);
            string title = Title.FormatStringLength(38);
            string publisher = Publisher.FormatStringLength(23);

            output = string.Format("{0,-20} {1,-40} {2,-8} {3,-25} {4,-20} {5,-15}", $"{author}",
            $"| {title}", $"| {YearOfPublication}", $"| {publisher}", $"| {ISBN}", "| Novel");
            
            return output;
        }
    }    
}