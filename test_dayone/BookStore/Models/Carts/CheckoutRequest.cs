using System.Collections.Generic;

namespace BookStore.Models.Carts
{
    public class CheckoutRequest
    {
        public string CustomerId { get; set; }


        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<OrderDetailVm> OrderDetails { set; get; } = new List<OrderDetailVm>();
    }
}
