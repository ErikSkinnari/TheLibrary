namespace LibraryClassLibrary
{
    public class EBook : Book
    {
        public int LengthInMinutes { get; set; }

        public EBook(string author, string title, string publisher, string yearOfPublication, string isbn, int length)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            YearOfPublication = yearOfPublication;
            ISBN = isbn;
            LengthInMinutes = length;
        }

        public override string ToString()
        {
            string output;

            string author = Author.FormatStringLength(20);
            string title = Title.FormatStringLength(38);
            string publisher = Publisher.FormatStringLength(23);

            output = string.Format("{0,-20} {1,-40} {2,-8} {3,-25} {4,-20} {5,-15} {6}", $"{author}", 
            $"| {title}", $"| {YearOfPublication}", $"| {publisher}", $"| {ISBN}", "| E-Book ", $"| Length(minutes): {LengthInMinutes}");
            
            return output;
        }
    }
}