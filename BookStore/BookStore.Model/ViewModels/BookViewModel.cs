namespace BookStore.Model.ViewModels
{
    public class BookViewModel
    {
        public int Id { set; get; }

        public string Name { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public decimal Price { set; get; }
        public string AuthorName { set; get; }
        public int AuthorId { set; get; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

    }
}
