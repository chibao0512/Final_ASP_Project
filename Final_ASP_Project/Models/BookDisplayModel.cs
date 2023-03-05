namespace Final_ASP_Project.Models
{
    public class BookDisplayModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string STerm { get; set; } = "";
        public int GenreId { get; set; } = 0;

        public static implicit operator BookDisplayModel(BookDisplay.BookDisplayModel v)
        {
            throw new NotImplementedException();
        }
    }
}
