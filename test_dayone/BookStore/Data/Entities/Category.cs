using System.Collections.Generic;

namespace BookStore.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookInCategory> BookInCategories { get; set; }

    }
}
