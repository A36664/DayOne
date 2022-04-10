using System;

namespace BookStore.Data.Entities
{
    public class Input
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public int Total { get; set; }

        public Book Book { get; set; }
        public DateTime  DateIn { get; set; }

    }
}
