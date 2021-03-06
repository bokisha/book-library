using BookLibrary.Core.Enums;
using System;

namespace BookLibrary.Core.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
