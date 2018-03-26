namespace FavBooks.Models.Books
{
    public class BookModel
    {
        /// <summary>
        /// ISBN of the book (ISBN13 format)
        /// </summary>
        public long ISBN { get; set; }
        /// <summary>
        /// The title, or all titles concatinated with comma or empty if missing
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Base64 data/image url that you can directly display, resized to 200x200, or empty if missing
        /// </summary>
        public string CoverThumb { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Subtitle if Sexists
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// Comma seperated list of book's subjects according to their NUR code, could be empty string
        /// </summary>
        public string Subjects { get; set; }
        /// <summary>
        /// Comma seperated list of authors
        /// </summary>
        public string Authors { get; set; }
    }
}
