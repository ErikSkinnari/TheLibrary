namespace LibraryClassLibrary
{
    public abstract class Book
    {
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string YearOfPublication { get; set; }
        public string ISBN { get; set; }     
    }
}