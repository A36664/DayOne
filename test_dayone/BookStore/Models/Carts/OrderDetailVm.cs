namespace BookStore.Models.Carts
{
    public class OrderDetailVm
    {
        public int BookId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
