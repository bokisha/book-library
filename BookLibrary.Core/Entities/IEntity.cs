using System;

namespace BookLibrary.Core.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }

    }
}
