using System;

namespace BookStore.Data.Entities
{
    public class OutPut
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Total { get; set; }

        public DateTime  DateOut { get; set; }
    }
}
