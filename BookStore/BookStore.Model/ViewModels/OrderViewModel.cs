using BookStore.Model.Entities;
using System.Collections.Generic;

namespace BookStore.Model.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
