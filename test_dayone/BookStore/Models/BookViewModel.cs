namespace BookStore.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public decimal Price { set; get; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
    }
}
