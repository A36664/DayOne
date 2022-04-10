using System.Collections.Generic;

namespace BookStore.Data.Entities
{
    public class Author
    {
       public int Id { get; set; }
        public string Name { get; set; }
       public List<Book> Books { get; set; }

    }
}
