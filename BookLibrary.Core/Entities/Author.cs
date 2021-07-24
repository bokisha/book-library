using System;

namespace BookLibrary.Core.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedUtc{ get; set; }
        public DateTime ModifiedUtc { get; set; }

    }
}
