namespace LibraryClassLibrary
{
    public class ShortStory : Book
    {
        public int Pages { get; set; }

        public ShortStory(string author, string title, string publisher, string yearOfPublication, string isbn, int pages)
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
            string title = Title.FormatStringLength(35);
            string publisher = Publisher.FormatStringLength(20);

            output = string.Format("{0,-20} {1,-40} {2,-30} {3,-20} {4,-15}", $"{author}", $"| {title}", $"| {publisher}", $"| {ISBN}", "| Short Story");
            
            return output;
        }
    }
}