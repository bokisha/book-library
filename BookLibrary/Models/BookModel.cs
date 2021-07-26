using BookLibrary.Core.Enums;
using BookLibrary.Core.Models;
using System;

namespace BookLibrary.Models
{
    public class BookModel : IViewModel
    {
        public int Id { get; set; }

        public DateTime ModifiedUtc { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string GenreString { get; set; }
        public int AuthorId { get; set; }
        public string AuthorString { get; set; }
    }
}
