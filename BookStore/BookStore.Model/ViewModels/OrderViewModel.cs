using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
    }
}
