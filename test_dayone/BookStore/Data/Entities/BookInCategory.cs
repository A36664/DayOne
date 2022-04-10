namespace BookStore.Data.Entities
{
    public class BookInCategory
    {
        public int CategoryId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Category Category { get; set; }


    }
}
