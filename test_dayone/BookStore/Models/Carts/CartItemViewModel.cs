namespace BookStore.Models.Carts
{
    public class CartItemViewModel
    {
        public int BookId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
