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
            string title = Title.FormatStringLength(35);
            string publisher = Publisher.FormatStringLength(20);

            output = string.Format("{0,-20} {1,-40} {2,-30} {3,-20} {4,-15} {5}", $"{author}", 
            $"| {title}", $"| {publisher}", $"| {ISBN}", "| E-Book ", $"| Length(minutes): {LengthInMinutes}");
            
            return output;
        }
    }
}