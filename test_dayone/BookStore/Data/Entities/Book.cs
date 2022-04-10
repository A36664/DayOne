using System.Collections.Generic;

namespace BookStore.Data.Entities
{
    public class Book
    {
        public int Id { set; get; }
         public string Name { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public decimal Price { set; get; }

        public List<BookInCategory> BookInCategories { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
       public int AuthorId { set; get; }
        public Author Author { set; get; }

        public List<OutPut> Outputs { get; set; }
        public List<Input> Inputs { get; set; }
    }
}
